
using System;

namespace Teenpatti.Data.API
{
    [Serializable]
    public class Player
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
        public string country;
        public string timezone;
        public string respinAvailableAt;
        public DateTime createdAt;
        public DateTime updatedAt;
    }
}
