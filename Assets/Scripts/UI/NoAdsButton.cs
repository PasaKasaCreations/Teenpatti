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

        [Header("No Ads Data")]
        [SerializeField]
        private NoAdsGetResponseData[] noAdsData;

        private void OnEnable()
        {
            noAdButton.onClick.AddListener(OnNoAdButtonClicked);
        }

        private void Start()
        {
           GetNodAds();
        }

        private void GetNodAds()
        {
            APIManager.Instance.Get<NoAdsGetResponse>(APIConstants.GetNoAds,
            (response) =>
            {
                noAdsData = response.data;
            },
            (error) =>
            {

            });
        }

        private void OnNoAdButtonClicked()
        {
            if (noAdsData == null || noAdsData.Length == 0) return;

            APIManager.Instance.Post<PurchaseNoAds, PurchaseNoAdsResponse>(APIConstants.PurchaseNoAds,
            new()
            {
                subscriptionId = noAdsData[0].id
            },
            (response) =>
            {

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
