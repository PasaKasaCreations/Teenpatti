using ScriptableObjects.Data;
using System;
using UnityEngine;

namespace Helpers
{
    public class DeepLinking : MonoBehaviour
    {
        [SerializeField]
        private ReferralDetails referralDetails;

        private void OnEnable()
        {
            Application.deepLinkActivated += OnDeepLinkActivated;
        }

        private void Awake()
        {
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                OnDeepLinkActivated(Application.absoluteURL);
            }
        }

        private void OnDeepLinkActivated(string url)
        {
            ExtractReferralId(url);
        }

        private void ExtractReferralId(string url)
        {
            string referralId = url.Split(new[] { "invite/", "#" }, StringSplitOptions.None)[1];
            referralDetails.SetReferralId(referralId);
        }

        private void OnDisable()
        {
            Application.deepLinkActivated -= OnDeepLinkActivated;
        }
    }
}