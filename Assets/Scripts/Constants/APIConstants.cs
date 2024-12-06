using UnityEngine;

namespace Constants
{
    public static class APIConstants
    {
        public const string APIURI = "http://192.168.1.90:8081/api/v1/";

        public const string GuestLogin = APIURI + "auth/guest/login";
    }
}
