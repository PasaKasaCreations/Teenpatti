using System.Security.Cryptography;
using System.Text;
using System;
using UnityEngine;
using API;
using Constants;
using Newtonsoft.Json;
using ScriptableObjects.Data;
using Teenpatti.Data;
using Enums;
using Teenpatti.Data.Secrets;

namespace Ads
{
    public class S2SAds : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField]
        private PlayerDetails playerDetails;

        [Header("Secret Data")]
        [SerializeField]
        private TextAsset secretText;

        public void ReedemAPI(AdType adType)
        {
            string secretId = "";
            SendAd sendAdData = new()
            {
                adType = adType.ToString(),
                id = null,
                playerId = playerDetails.id,
                platform = Application.platform == RuntimePlatform.IPhonePlayer ? "ios" : "android"
            };
            string sendAdDataJson = JsonConvert.SerializeObject(sendAdData);
            string guid = Guid.NewGuid().ToString();
            Secrets secrets = JsonConvert.DeserializeObject<Secrets>(secretText.text);
            secretId = Application.platform == RuntimePlatform.IPhonePlayer ? secrets.IOS_ID : secrets.ANDROID_ID;
            string hmac = GetHMAC($"oid={guid},productid={1234},sid={sendAdDataJson}", secretId);
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
