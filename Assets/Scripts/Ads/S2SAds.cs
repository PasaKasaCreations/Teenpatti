using System.Security.Cryptography;
using System.Text;
using System;
using UnityEngine;
using API;
using Constants;
using Newtonsoft.Json;
using ScriptableObjects.Data;
using Teenpatti.Data;

namespace Ads
{
    public class S2SAds : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField]
        private PlayerDetails playerDetails;

        public void ReedemAPI()
        {
            SendAd sendAdData = new()
            {
                adType = "FREE_CHIPS",
                id = null,
                playerId = playerDetails.id
            };
            string sendAdDataJson = JsonConvert.SerializeObject(sendAdData);
            string guid = Guid.NewGuid().ToString();
            string hmac = GetHMAC($"oid={guid},productId={1234},sid={sendAdDataJson}", "88caea60363ff21b2fb1c970928e1e86");
            APIManager.Instance.Get<object>(APIConstants.ReedemAd +
                $"productid={1234}&sid={sendAdDataJson}&oid={guid}&hmac={hmac}");
        }

        private string GetHMAC(string text, string key)
        {
            using HMACMD5 hmacMD5 = new HMACMD5(Encoding.UTF8.GetBytes(key));
            byte[] hash = hmacMD5.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
