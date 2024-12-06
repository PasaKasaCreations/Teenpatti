using API;
using Constants;
using Teenpatti.Data.API;
using UnityEngine;
using UnityEngine.UI;

namespace Teenpatti.UI
{
    public class LoginUI : MonoBehaviour
    {
        public void Login()
        {
            APIManager.Instance.Post<GuestLoginData, string>(APIConstants.APIURI + APIConstants.GuestLogin, new GuestLoginData()
            {
                deviceId = "9774d56d682e549c"
            },
            (w) =>
            {
                print("Successfully LoggedIn...");
            },
            () =>
            {
                print("Error while logging in");
            });
        }
    }
}
