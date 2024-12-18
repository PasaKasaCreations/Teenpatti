
namespace Teenpatti.Data.API
{
    public class GetReferralResponse
    {
        public bool success;
        public string message;
        public GetReferralResponseData data;
    }

    public class GetReferralResponseData
    {
        public string referralCode;
        public string referralLink;
        public int totalReferrals;
    }
}
