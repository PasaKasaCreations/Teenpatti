
namespace Teenpatti.Data
{
    public class ClaimRewardResponse
    {
        public bool success;
        public string message;
        public ClaimRewardResponseData data;
    }

    public class ClaimRewardResponseData
    {
        public string id;
        public string coins;
        public int gems;
        public PlayerMetaData PlayerMetaData;
    }

    public class PlayerMetaData
    {
        public string dailyRewardClaimedAt;
        public int rewardStreakCount;
    }
}
