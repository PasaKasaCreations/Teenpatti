
namespace Teenpatti.Data.API
{
    public class GuestLogin
    {
        public string deviceId;
        public string country;
        public string timezone;
        public string referralCode;
    }

    public class GuestLoginResponse
    {
        public bool success;
        public string message;
        public LoginData data;
    }

    public class LoginData
    {
        public string id;
        public int systemId;
        public int level;
        public int xp;
        public string coins;
        public int gems;
        public string avatar;
        public bool isGuest;
        public string deviceId;
        public string referralCode;
        public string country;
        public string timezone;
        public string respinAvailableAt;
        public NoAdsSubscription noAdsSubscription;
        public string referral;
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
