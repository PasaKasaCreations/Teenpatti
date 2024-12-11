using API;
using Constants;
using ScriptableObjects.Logging;
using Teenpatti.Data.API;
using UnityEngine;

namespace Teenpatti.Rewards
{
    public class RewardManager : MonoBehaviour
    {
        [Header("Rewards")]
        [SerializeField]
        private DailyRewardData dailyRewardData;

        [Header("Debugger")]
        [SerializeField]
        private Debugger apiDebugger;

        [ContextMenu("Get Daily Reward")]
        private void GetDailyRewards()
        {
            APIManager.Instance.Get<DailyReward>(APIConstants.GetDailyRewards,
            (response) =>
            {
                dailyRewardData = response.data;
            },
            (error) =>
            {
                apiDebugger.Log(error.message, Enums.LoggingType.Warning);
            },
            new()
            {
                {"Authorization", $"Bearer {Authenticator.Instance.GetAccessToken()}"}
            });
        }

        private void ClaimDailyReward(string dailyRewardId)
        {
            APIManager.Instance.Post<ClaimReward, ClaimRewardResponse>(APIConstants.ClaimDailyReward,
            new()
            {
                dailyRewardId = dailyRewardId,
            },
            (response) =>
            {
                apiDebugger.Log(response.message);
            },
            (error) =>
            {
                apiDebugger.Log(error.message, Enums.LoggingType.Warning);
            },
            new()
            {
                {"Authorization", $"Bearer {Authenticator.Instance.GetAccessToken()}"}
            });
        }

        [ContextMenu("Claim Daily Reward")]
        private void TestClaimDailyReward()
        {
            ClaimDailyReward(dailyRewardData.records[0].id);
        }
    }
}
