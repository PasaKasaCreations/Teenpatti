using Enums;
using ScriptableObjects.Logging;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
    {
        [Header("Ad Units")]
        [SerializeField] private string androidGameId;
        [SerializeField] private string iOSGameId;
        [SerializeField] private bool testMode = true;
        private string _gameId;

        [Header("Ads")]
        [SerializeField]
        private InterstitialAd interstitialAd;
        [SerializeField]
        private RewardedAd rewardedAd;

        [Header("Logger")]
        [SerializeField]
        private Debugger adsLogger;

        void Awake()
        {
            InitializeAds();
        }

        public void InitializeAds()
        {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
            _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = androidGameId; 
#endif
            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                Advertisement.Initialize(_gameId, testMode, this);
            }
        }

        public void OnInitializationComplete()
        {
            adsLogger.Log("Unity Ads initialization completed.");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            adsLogger.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}", LoggingType.Warning);
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