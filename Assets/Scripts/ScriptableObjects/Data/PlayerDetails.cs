using System;
using Teenpatti.Data.API;
using UnityEngine;

namespace ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "Player Details", menuName = "Data/Player Details")]
    public class PlayerDetails : ScriptableObject
    {
        public string id;
        public int level;
        public string coins;
        public int gems;
        public int xp;
        public bool isGuest;
        public string country;
        public string timeZone;
        public DateTime respinAvailableAt;

        public void UpdateDetails(LoginData loginData)
        {
            DateTime respinAvailableTime;
            DateTime.TryParse(loginData.respinAvailableAt, out respinAvailableTime);

            id = loginData.id;
            level = loginData.level;
            coins = loginData.coins;
            gems = loginData.gems;
            isGuest = loginData.isGuest;
            timeZone = loginData.timezone;
            respinAvailableAt = respinAvailableTime;
        }
    }
}
