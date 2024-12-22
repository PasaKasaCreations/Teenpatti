using API;
using Constants;
using Helpers;
using ScriptableObjects.Data;
using Socket;
using System;
using System.Globalization;
using System.IO;
using Teenpatti.Data.API;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
                timezone = "Asia/Kathmandu",
                referralCode = null
            },
           (response) =>
           {
               Authenticator.Instance.SetToken(response.data.accessToken, response.data.refreshToken);
               playerDetails.UpdateDetails(response.data);
               SocketManager.Instance.Initialize();

               APIManager.Instance.DownloadImage(response.data.avatar.path,
                  (texture) =>
                  {
                      Sprite avatarSprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), Vector2.zero);
                      playerDetails.UpdateAvatar(avatarSprite);
                  });

               APIManager.Instance.DownloadImage(response.data.frame.path,
                  (texture) =>
                  {
                      Sprite frameSprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), Vector2.zero);
                      playerDetails.UpdateFrame(frameSprite);

                      SceneLoaderUnloader.Instance.ChangeAsync(dashboardScene, LoadSceneMode.Additive);
                      SceneLoaderUnloader.Instance.UnloadSceneAsync(menuScene);
                  });
           },
           (error) =>
           {
               print(error.message);
           });
        }
    }
}
