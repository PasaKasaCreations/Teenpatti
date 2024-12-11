namespace Teenpatti.Data.API
{
    public class OfferResponse
    {
        public bool success;
        public string message;
        public OfferData[] data;
    }

    public class OfferData
    {
        public string id;
        public string imagePath;
        public string rewardValue;
        public int watchAds;
        public bool isCompleted;
        public int watchAdsCount;
    }
}
