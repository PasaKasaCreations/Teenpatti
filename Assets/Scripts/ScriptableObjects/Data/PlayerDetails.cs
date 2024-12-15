using Teenpatti.Data.API;
using UnityEngine;

namespace ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "Player Details", menuName = "Data/Player Details")]
    public class PlayerDetails : ScriptableObject
    {
        public int level;
        public string coins;
        public int gems;
        public int xp;
        public bool isGuest;
        public string country;
        public string timeZone;

        public void UpdateDetails(LoginData loginData)
        {
            level = loginData.level;
            coins = loginData.coins;
            gems = loginData.gems;
            isGuest = loginData.isGuest;
            timeZone = loginData.timezone;
        }
    }
}
