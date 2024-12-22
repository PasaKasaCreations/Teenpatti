using API;
using Constants;
using Teenpatti.Data;
using Teenpatti.Data.API;
using UnityEngine;
using UnityEngine.UI;

namespace Teenpatti.UI
{
    public class NoAdsButton : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private Button noAdButton;
        [SerializeField]
        private NoAdsUI noAdsUI;

        private void OnEnable()
        {
            noAdButton.onClick.AddListener(OnNoAdButtonClicked);
        }

        private void OnNoAdButtonClicked()
        {
            GetNodAds();
        }

        private void GetNodAds()
        {
            APIManager.Instance.Get<NoAdsGetResponse>(APIConstants.GetNoAds,
            (response) =>
            {
                noAdsUI.UpdateNoAdsInnerUI(response.data);
                noAdsUI.gameObject.SetActive(true);
            },
            (error) =>
            {

            });
        }

        private void OnDisable()
        {
            noAdButton.onClick.RemoveAllListeners();
        }
    }
}
