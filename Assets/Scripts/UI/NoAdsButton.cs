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

        private void OnEnable()
        {
            noAdButton.onClick.AddListener(OnNoAdButtonClicked);
        }

        [ContextMenu("Get No Ads")]
        private void GetNodAds()
        {
            APIManager.Instance.Get<NoAdsGetResponse>(APIConstants.GetNoAds,
            (response) =>
            {

            },
            (error) =>
            {

            });
        }

        private void OnNoAdButtonClicked()
        {
            APIManager.Instance.Post<PurchaseNoAds, PurchaseNoAdsResponse>(APIConstants.PurchaseNoAds,
            new()
            {
                subscriptionId = ""
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
