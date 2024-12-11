using System;

namespace Teenpatti.Data.API
{
    public class ClaimReward
    {
        public string dailyRewardId;
    }

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

    [Serializable]
    public class DailyReward
    {
        public bool success;
        public string message;
        public DailyRewardData data;
    }

    [Serializable]
    public class DailyRewardData
    {
        public string content;
        public DailyRewardRecord[] records;
    }

    [Serializable]
    public class DailyRewardRecord
    {
        public string id;
        public int streakDays;
        public string rewardValue;
        public bool isClaimed;
        public string rewardUnlockedAt;
    }
}
