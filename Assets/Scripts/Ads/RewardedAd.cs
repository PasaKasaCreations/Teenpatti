using Enums;
using ScriptableObjects.Data;
using ScriptableObjects.EventBus;
using ScriptableObjects.Logging;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class RewardedAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        [Header("Ad Units")]
        [SerializeField] private string androidAdUnitId = "Rewarded_Android";
        [SerializeField] private string iOSAdUnitId = "Rewarded_iOS";
        private string _adUnitId = null;

        [Header("Data")]
        [SerializeField]
        private PlayerDetails playerDetails;

        [Header("S2S Ads")]
        [SerializeField]
        private S2SAds s2sAds;

        [Header("Events")]
        [SerializeField]
        private IntEventChannel RewardedEvent;

        [Header("Logger")]
        [SerializeField]
        private Debugger adsLogger;

        void Awake()
        {
            _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? iOSAdUnitId
                : androidAdUnitId;

#if UNITY_EDITOR
            _adUnitId = androidAdUnitId;
#endif
        }

        public void LoadAd()
        {
            adsLogger.Log("Loading Ad: " + _adUnitId);
            Advertisement.Load(_adUnitId, this);
        }

        public void OnUnityAdsAdLoaded(string adUnitId)
        {
            adsLogger.Log("Ad Loaded: " + adUnitId);
            ShowAd();
        }

        public void ShowAd()
        {
            ShowOptions options = new()
            {
                gamerSid = playerDetails.id,
            };
            Advertisement.Show(_adUnitId, options, this);
        }

        public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
        {
            if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
            {
                adsLogger.Log("Unity Ads Rewarded Ad Completed");
                RewardedEvent.Raise(50);
                s2sAds.ReedemAPI();
            }
        }

        public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
        {
            adsLogger.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}", LoggingType.Warning);
        }

        public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
        {
            adsLogger.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}", LoggingType.Warning);
        }

        public void OnUnityAdsShowStart(string adUnitId) { }
        public void OnUnityAdsShowClick(string adUnitId) { }
    }
}

