using API;
using Constants;
using Helpers;
using Teenpatti.Data;
using Teenpatti.Data.API;
using UnityEngine;

namespace Teenpatti
{
    public class Authenticator : Singleton<Authenticator>
    {
        [ContextMenu("Refresh Login")]
        public void RefreshLogin()
        {
            APIManager.Instance.Post<RefreshLogin, RefreshLoginResponse>(APIConstants.RefreshLogin, new RefreshLogin()
            {
                refreshToken = GetRefreshToken(),
            },
           (response) =>
           {
               SetToken(response.data.accessToken, response.data.refreshToken);
           },
           (error) =>
           {
               print(error.message[0]);
           });
        }

        public void SetToken(string accessToken, string refreshToken)
        {
            PlayerPrefs.SetString(SocketConstants.AccessToken, accessToken);
            PlayerPrefs.SetString(SocketConstants.RefreshToken, refreshToken);
        }

        public string GetAccessToken() => PlayerPrefs.GetString(SocketConstants.AccessToken);

        public string GetRefreshToken() => PlayerPrefs.GetString(SocketConstants.RefreshToken);
    }
}
