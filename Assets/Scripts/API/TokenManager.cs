using API;
using Constants;
using Helpers;
using Teenpatti.Data.API;
using UnityEngine;

namespace Teenpatti
{
    public class TokenManager : Singleton<TokenManager>
    {
        public string GetToken()
        {
            return PlayerPrefs.GetString(SocketConstants.AccessToken);
        }

        public void SetToken(string accessToken, string refreshToken)
        {
            PlayerPrefs.SetString(SocketConstants.AccessToken, accessToken);
            PlayerPrefs.SetString(SocketConstants.RefreshToken, refreshToken);
        }
    }
}
