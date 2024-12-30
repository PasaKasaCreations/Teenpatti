using System;

namespace Teenpatti.Data.API
{
    public class GetStoreDataResponse
    {
        public bool success;
        public string message;
        public StoreData[] data;
    }

    [Serializable]
    public class StoreData
    {
        public string id;
        public string type;
        public string reward;
        public int cost;
        public bool gemPurchase;
        public bool isDisabled;
        public DateTime createdAt;
        public DateTime updatedAt;
    }

    public class PurchaseCoin
    {
        public string purchaseBundleId;
    }

    public class PurchaseCoinResponse
    {
        public bool success;
        public string message;
        public PurchaseCoinData data;
    }

    public class PurchaseCoinData
    {
        public string id;
        public int systemId;
        public string coins;
        public int gems;
    }

    public class PurchaseGems
    {
        public string purchaseBundleId;
    }

    public class PurchaseGemsResponse
    {
        public bool success;
        public string message;
        public PurchaseGemsData data;
    }

    public class PurchaseGemsData
    {
        public string id;
        public int systemId;
        public string coins;
        public int gems;
    }
}
