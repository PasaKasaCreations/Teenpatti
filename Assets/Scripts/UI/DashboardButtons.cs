using Ads;
using UnityEngine;
using UnityEngine.UI;

namespace Teenpatti.UI
{
    public class DashboardButtons : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField]
        private Button freechipsButton;
        [SerializeField]
        private Button spinwheelButton;

        [Header("Canvases")]
        [SerializeField]
        private Canvas spinWheelCanvas;

        private void OnEnable()
        {
            freechipsButton.onClick.AddListener(ShowAds);
            spinwheelButton.onClick.AddListener(ShowSpinWheel);
        }

        private void ShowAds()
        {
            AdsManager.Instance.ShowRewardedAd();
        }

        private void ShowSpinWheel()
        {
            spinWheelCanvas.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            freechipsButton.onClick.RemoveAllListeners();
            spinwheelButton.onClick.RemoveAllListeners();
        }
    }
}
