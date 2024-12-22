using Ads;
using Enums;
using ScriptableObjects.EventBus;
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
            AdsManager.Instance.ShowRewardedAd(AdType.FREE_CHIPS);
        }

        private void OnDisable()
        {
            freechipsButton.onClick.RemoveAllListeners();
        }
    }
}
