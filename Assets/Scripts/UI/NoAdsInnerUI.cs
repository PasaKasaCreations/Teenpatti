using API;
using Constants;
using Teenpatti.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Teenpatti.UI
{
    public class NoAdsInnerUI : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private TMP_Text dayText;
        [SerializeField]
        private TMP_Text gemsText;
        [SerializeField]
        private Button noAdInnerButton;

        [Header("Data")]
        [SerializeField]
        private NoAdsGetResponseData noAdsGetResponseData;

        private void OnEnable()
        {
            noAdInnerButton.onClick.AddListener(() => OnNoAdInnerButtonClicked(noAdsGetResponseData.id));
        }

        public void UpdateDayText(int days) => dayText.text = days.ToString();

        public void UpdateGemsText(int gems) => gemsText.text = gems.ToString();

        private void OnNoAdInnerButtonClicked(string id)
        {
            APIManager.Instance.Post<PurchaseNoAds, PurchaseNoAdsResponse>(APIConstants.PurchaseNoAds,
            new()
            {
                subscriptionId = id
            },
            (response) =>
            {

            },
            (error) =>
            {

            });
        }

        public void SetNoAdsGetResponseData(NoAdsGetResponseData noAdsGetResponseData) => this.noAdsGetResponseData = noAdsGetResponseData;

        private void OnDisable()
        {
            noAdInnerButton.onClick.RemoveAllListeners();
        }
    }
}
