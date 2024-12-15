using Ads;
using UnityEngine;
using UnityEngine.UI;

namespace Teenpatti.UI
{
    public class FreeChipsUI : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField]
        private Button freechipsButton;

        private void OnEnable()
        {
            freechipsButton.onClick.AddListener(ShowAds);
        }

        private void ShowAds()
        {
            AdsManager.Instance.ShowRewardedAd();
        }

        private void OnDisable()
        {
            freechipsButton.onClick.RemoveAllListeners();
        }
    }
}
