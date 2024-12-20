
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
        public bool isGuest;
        public string deviceId;
        public string referralCode;
        public string country;
        public string timezone;
        public string respinAvailableAt;
        public NoAdsSubscription noAdsSubscription;
        public ReferralData referral;
        public Avatar avatar;
        public Frame frame;
        public string accessToken;
        public string refreshToken;
    }

    public class ReferralData
    {
        public bool success;
        public string message;
        public int rewardedAmount;
    }

    public class Avatar
    {
        public string id;
        public bool isTrial;
        public string expiresAt;
        public string path;
    }

    public class Frame
    {
        public string id;
        public bool isTrial;
        public string expiresAt;
        public string path;
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
