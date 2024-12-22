using Teenpatti.Data;
using UnityEngine;

namespace Teenpatti.UI
{
    public class NoAdsUI : MonoBehaviour
    {
        [Header("No Ads Inner UI Data")]
        [SerializeField]
        private NoAdsInnerUI[] noAdsInnerUIs;

        public void UpdateNoAdsInnerUI(NoAdsGetResponseData[] noAdsData)
        {
            for (int i = 0; i < noAdsInnerUIs.Length; i++)
            {
                NoAdsInnerUI noAdsInnerUI = noAdsInnerUIs[i];
                noAdsInnerUI.UpdateDayText(noAdsData[i].days);
                noAdsInnerUI.UpdateGemsText(noAdsData[i].gems);
                noAdsInnerUI.SetNoAdsGetResponseData(noAdsData[i]);
            }
        }
    }
}
