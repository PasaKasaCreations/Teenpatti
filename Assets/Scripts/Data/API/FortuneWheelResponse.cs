using System;

namespace Teenpatti.Data.API
{
    public class FortuneWheelResponse
    {
        public bool success;
        public string message;
        public FortuneWheelData[] data;
    }

    public class FortuneWheelData
    {
        public string type;
        public string value;
    }

    public class Root
    {
        public bool success;
        public string message;
        public FortuneWheelSpinData data;
    }

    public class FortuneWheelSpinData
    {
        public FortuneWheelSpinPlayer player;
        public int winIndex;
        public FortuneWheelWinValue winValue;
        public DateTime respinAvailableAt;
    }

    public class FortuneWheelSpinPlayer
    {
        public int systemId;
        public int level;
        public int xp;
        public string coins;
        public int gems;
    }

    public class FortuneWheelWinValue
    {
        public string type;
        public string value;
    }
}
