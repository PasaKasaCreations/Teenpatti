using UnityEngine;

namespace Constants
{
    public static class APIConstants
    {
        public const string APIURI = "https://api-3.pasakasacreations.com/api/v1/";

        public const string GuestLogin = APIURI + "auth/guest/login";
        public const string RefreshLogin = APIURI + "auth/refresh-token";

        public const string GetDailyReward = APIURI + "daily-reward";
    }
}
