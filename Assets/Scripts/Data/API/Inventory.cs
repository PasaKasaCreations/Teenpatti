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

    }

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
}
