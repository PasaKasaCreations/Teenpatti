using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        [SerializeField] private string androidGameId;
        [SerializeField] private string iOSGameId;
        [SerializeField] private bool testMode = true;
        private string _gameId;

        [SerializeField]
        private InterstitialAd interstitialAd;
        [SerializeField]
        private RewardedAd rewardedAd;

        void Awake()
        {
            InitializeAds();
        }

        public void InitializeAds()
        {
#if UNITY_IOS
        _gameId = _iOSGameId;
#elif UNITY_ANDROID
        //_gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = androidGameId; //Only for testing the functionality in the Editor
#endif
            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                Advertisement.Initialize(_gameId, testMode, this);
            }
        }

        public void OnInitializationComplete()
        {
            Debug.Log("Unity Ads initialization complete.");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        }

        [ContextMenu("Show Interstitial Ad")]
        public void ShowInterstitialAd()
        {
            interstitialAd.LoadAd();
        }

        [ContextMenu("Show Rewarded Ad")]
        public void ShowRewardedAd()
        {
            rewardedAd.LoadAd();
        }
    }
}