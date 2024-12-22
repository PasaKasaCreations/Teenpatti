
using System;

namespace Teenpatti.Data
{
    public class NoAdsGetResponse
    {
        public string success;
        public string message;
        public NoAdsGetResponseData[] data;
    }

    [Serializable]
    public class NoAdsGetResponseData
    {
        public string id;
        public int gems;
        public int days;
        public bool isExpired;
        public string createdAt;
        public string updatedAt;
    }

    public class PurchaseNoAds
    {
        public string subscriptionId;
    }

    public class PurchaseNoAdsResponse
    {
        public string success;
        public string message;
        public PurchaseNoAdsResponseData data;
    }

    public class PurchaseNoAdsResponseData
    {
        public string id;
        public int gems;
        public int days;
        public bool isExpired;
        public string createdAt;
        public string updatedAt;
    }

    public class NoAdsSubscription
    {
        public string id;
        public string expiredOn;
    }
}
