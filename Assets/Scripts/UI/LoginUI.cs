using API;
using Constants;
using Helpers;
using ScriptableObjects.Data;
using Socket;
using System;
using System.Globalization;
using Teenpatti.Data.API;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Teenpatti.UI
{
    public class LoginUI : MonoBehaviour
    {
        [Header("Scenes")]
        [SerializeField]
        private SceneField menuScene;
        [SerializeField]
        private SceneField dashboardScene;

        [Header("Player Details")]
        [SerializeField]
        private PlayerDetails playerDetails;

        public void GeustLogin()
        {
            APIManager.Instance.Post<GuestLogin, GuestLoginResponse>(APIConstants.GuestLogin, new GuestLogin()
            {
                deviceId = SystemInfo.deviceUniqueIdentifier,
                country = RegionInfo.CurrentRegion.TwoLetterISORegionName,
                timezone = "America/New_York"
            },
           (response) =>
           {
               Authenticator.Instance.SetToken(response.data.accessToken, response.data.refreshToken);
               playerDetails.UpdateDetails(response.data);
               SocketManager.Instance.Initialize();
               SceneLoaderUnloader.Instance.ChangeAsync(dashboardScene, LoadSceneMode.Additive);
               SceneLoaderUnloader.Instance.UnloadSceneAsync(menuScene);
           },
           (error) =>
           {
               print(error.message);
           });
        }
    }
}
