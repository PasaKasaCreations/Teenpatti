
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
    }
}   
