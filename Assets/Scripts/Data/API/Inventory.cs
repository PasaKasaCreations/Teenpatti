using System;

namespace Teenpatti.Data.API
{
    public class GetAllInventoryResponse
    {
        public bool success;
        public string message;
        public InventoryData[] data;
        public int totalCount;
    }

    public class GetOwnedInventoryResponse
    {
        public bool success;
        public string message;
        public OwnedInventoryData[] data;
    }

    [Serializable]
    public class OwnedInventoryData
    {
        public string id;
        public string inventoryItemId;
        public string acquiredAt;
        public string expiresAt;
        public InventoryData[] InventoryItems;
        public string path;
    }

    [Serializable]
    public class InventoryData
    {
        public string id;
        public string type;
        public string name;
        public string path;
        public int cost;
        public bool isDefault;
        public bool isTrialAvailable;
        public int adWatchCount;
        public int trialDuration;
        public string createdAt;
        public string updatedAt;
    }

    public class PurchaseInventoryTrial
    {
        public string inventoryItemId;
    }

    public class PurchaseInventoryPermanent
    {
        public string inventoryItemId;
    }

    public class PurchaseInventoryTrialResponse
    {
        public bool success;
        public string message;
    }

    public class PurchaseInventoryPermanentResponse
    {
        public bool success;
        public string message;
    }
}
