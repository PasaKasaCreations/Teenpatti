using API;
using Constants;
using Helpers;
using Socket;
using Teenpatti.Data.API;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Teenpatti.UI
{
    public class LoginUI : MonoBehaviour
    {
        [SerializeField]
        private SceneField sceneField;

        public void GeustLogin()
        {
            APIManager.Instance.Post<GuestLogin, GuestLoginResponse>(APIConstants.GuestLogin, new GuestLogin()
            {
                deviceId = SystemInfo.deviceUniqueIdentifier,
            },
           (response) =>
           {
               Authenticator.Instance.SetToken(response.data.accessToken, response.data.refreshToken);
               SocketManager.Instance.Initialize();
               SceneChanger.Instance.ChangeAsync(sceneField);
           },
           (error) =>
           {
               print(error.message[0]);
           });
        }
    }
}
