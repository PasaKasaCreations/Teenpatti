using API;
using Constants;
using Teenpatti.Data.API;
using UnityEngine;
using UnityEngine.UI;

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
                TokenManager.Instance.SetToken(response.data.accessToken, response.data.refreshToken);
            },
            () =>
            {
                print("Error while logging in");
            });
        }
    }
}
