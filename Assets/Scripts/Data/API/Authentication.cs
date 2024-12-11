
namespace Teenpatti.Data.API
{
    public class GuestLogin
    {
        public string deviceId;
        public string country;
        public string timezone;
    }

    public class GuestLoginResponse
    {
        public bool success;
        public string message;
        public GuestLoginData data;
    }

    public class GuestLoginData
    {
        public Player player;
        public string accessToken;
        public string refreshToken;
    }

    public class RefreshLogin
    {
        public string refreshToken;
    }
    
    public class RefreshLoginResponse
    {
        public bool success;
        public string message;
        public RefreshLoginResponseData data;
    }

    public class RefreshLoginResponseData
    {
        public string accessToken;
        public string refreshToken;
    }
}
