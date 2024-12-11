
using System;

namespace Teenpatti.Data
{
    [Serializable]
    public class DailyReward
    {
        public bool success;
        public string message;
        public DailyRewardData data;

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
}
