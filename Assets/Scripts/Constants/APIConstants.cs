
namespace Constants
{
    public static class APIConstants
    {
        public const string APIURI = "https://api-3.pasakasacreations.com/api/v1/";

        public const string GuestLogin = APIURI + "auth/guest/login";
        public const string RefreshLogin = APIURI + "auth/refresh-token";

        public const string GetDailyRewards = APIURI + "daily-reward";
        public const string ClaimDailyReward = APIURI + "daily-reward/claim";

        public const string GetOffers = APIURI + "offers";

        public const string GetFortuneWheelValues = APIURI + "fortune-wheel/values";
        public const string SpinFortuneWheel = APIURI + "fortune-wheel/spin";

        public const string ReedemAd = APIURI + "watch-ads/redeem?";

        public const string GetNoAds = APIURI + "no-ads";
        public const string PurchaseNoAds = APIURI + "no-ads/purchase";

        public const string GetReferral = APIURI + "player/referral";

        public const string GetInventory = APIURI + "inventory";
        public const string GetOwnedInventory = APIURI + "inventory/owned?inventoryType=";

        public const string InventoryPurchaseTrial = APIURI + "inventory/purchase/trial";
        public const string InventoryPurchasePermanent = APIURI + "inventory/purchase/permanent";

        public const string GetPurchaseStoreItems = APIURI + "store?storeItemType=";
        public const string PurchaseCoins = APIURI + "store/purchase/coins";
        public const string PurchaseGems = APIURI + "store/purchase/gems";
    }
}   
