using API;
using Constants;
using Helpers;
using System;
using System.Collections;
using Teenpatti.Data.API;
using UnityEngine;

namespace Teenpatti
{
    public class Authenticator : Singleton<Authenticator>
    {
        [ContextMenu("Refresh Login")]
        public void RefreshLogin(Action recallCallback = null)
        {
            APIManager.Instance.Post<RefreshLogin, RefreshLoginResponse>(APIConstants.RefreshLogin, new RefreshLogin()
            {
                refreshToken = GetRefreshToken(),
            },
           (response) =>
           {
               SetToken(response.data.accessToken, response.data.refreshToken);
               recallCallback?.Invoke();
           },
           (error) =>
           {
               print(error.message);
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
