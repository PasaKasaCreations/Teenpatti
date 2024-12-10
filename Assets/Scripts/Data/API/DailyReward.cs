
namespace Teenpatti.Data
{
    public class DailyReward
    {
        public bool success;
        public string message;
        public Data data;
    }
    public class Data
    {
        public string content;
        public Record[] records;
    }

    public class Record
    {
        public string id;
        public int streakDays;
        public string rewardValue;
        public bool isClaimed;
        public string rewardUnlockedAt;
    }
}
