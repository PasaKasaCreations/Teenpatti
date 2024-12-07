using API;
using Constants;
using Socket;
using Teenpatti.Data.API;
using UnityEngine;

namespace Teenpatti.UI
{
    public class LoginUI : MonoBehaviour
    {
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
           },
           () =>
           {
               print("Error while logging in");
           });
        }
    }
}
