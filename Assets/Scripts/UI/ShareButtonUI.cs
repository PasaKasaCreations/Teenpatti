using API;
using Constants;
using System.Collections;
using Teenpatti.Data.API;
using UnityEngine;
using UnityEngine.UI;

namespace Teenpatti.UI
{
    public class ShareButtonUI : MonoBehaviour
    {
        [SerializeField]
        private Button shareButton;

        private void OnEnable()
        {
            shareButton.onClick.AddListener(OnShareButtonClicked);
        }

        private void OnShareButtonClicked()
        {
            APIManager.Instance.Get<GetReferralResponse>(APIConstants.GetReferral,
                (response) =>
                {
                    if (Application.platform == RuntimePlatform.Android)
                    {
                        ShareAndroidText(response.data.referralCode, response.data.referralLink);
                    }
                },
                (error) =>
                {

                });
        }

        private void ShareAndroidText(string referralCode, string referralLink)
        {
            StartCoroutine(ShareAppWithReferralAndroidCoroutine(referralCode, referralLink));
        }

        private IEnumerator ShareAppWithReferralAndroidCoroutine(string referralCode, string referralLink)
        {
            yield return new WaitForEndOfFrame();

            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            intentObject.Call<AndroidJavaObject>("setType", "text/plain");

            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Teen Patti VVIP - Subject");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TITLE"), "Teen Patti VVIP - Title");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), $"Hey! Use my code {referralCode} to install Teen Patti VVIP and we'll both get 1 Lakh chips for free! 🎉\r\n{referralLink} \r\nLet's play and win together! 💰");
            
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");
            currentActivity.Call("startActivity", jChooser);
        }

        private void OnDisable()
        {
            shareButton.onClick.RemoveAllListeners();

            StopAllCoroutines();
        }
    }
}
