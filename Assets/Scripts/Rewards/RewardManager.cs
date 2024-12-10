using API;
using Constants;
using Teenpatti.Data;
using UnityEngine;

namespace Teenpatti.Rewards
{
    public class RewardManager : MonoBehaviour
    {
        [ContextMenu("Get Daily Reward")]
        private void GetDailyReward()
        {
            APIManager.Instance.Get<DailyReward>(APIConstants.GetDailyReward,
            new()
            {
                {"Authorization", $"Bearer {Authenticator.Instance.GetAccessToken()}"}
            },
            (response) =>
            {

            },
            (error) =>
            {
                print(error.message[0]);
            });
        }
    }
}
