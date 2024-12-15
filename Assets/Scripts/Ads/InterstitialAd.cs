using Enums;
using ScriptableObjects.Logging;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        [Header("Ad Units")]
        [SerializeField] private string androidAdUnitId = "Interstitial_Android";
        [SerializeField] private string iOsAdUnitId = "Interstitial_iOS";
        private string _adUnitId;

        [Header("Logger")]
        [SerializeField]
        private Debugger adsLogger;

        void Awake()
        {
            _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? iOsAdUnitId
                : androidAdUnitId;
        }

        public void LoadAd()
        {
            adsLogger.Log("Loading Ad: " + _adUnitId);
            Advertisement.Load(_adUnitId, this);
        }

        public void ShowAd()
        {
            adsLogger.Log("Showing Ad: " + _adUnitId);
            Advertisement.Show(_adUnitId, this);
        }

        public void OnUnityAdsAdLoaded(string adUnitId)
        {
            ShowAd();
        }

        public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
        {
            adsLogger.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}", LoggingType.Warning);
        }

        public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
        {
            adsLogger.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}", LoggingType.Warning);
        }

        public void OnUnityAdsShowStart(string _adUnitId) { }
        public void OnUnityAdsShowClick(string _adUnitId) { }
        public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }
    }
}