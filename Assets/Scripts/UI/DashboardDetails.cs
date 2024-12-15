using ScriptableObjects.Data;
using System;
using TMPro;
using UnityEngine;

namespace Teenpatti.UI
{
    public class DashboardDetails : MonoBehaviour
    {
        [Header("Details")]
        [SerializeField]
        private TMP_Text levelText;
        [SerializeField]
        private TMP_Text coinText;
        [SerializeField]
        private TMP_Text gemText;
        [SerializeField]
        private TMP_Text speenWheelTimerText;
        [SerializeField]
        private TMP_Text availableInText;

        [Header("Player Details")]
        [SerializeField]
        private PlayerDetails playerDetails;

        private void Start()
        {
            UpdateLevelText(playerDetails.level);
            UpdateCoinText(playerDetails.coins);
            UpdateGemText(playerDetails.gems);
            UpdateSpinWheelTimer(playerDetails.respinAvailableAt);
        }

        private void UpdateLevelText(int level) => levelText.text = $"Level {level}";

        private void UpdateCoinText(string coins) => coinText.text = $"{coins}";

        private void UpdateGemText(int gems) => gemText.text = $"{gems}";

        private void UpdateSpinWheelTimer(DateTime respinAvailableAt)
        {
            string respinAvailableText = "";
            TimeSpan deltaTime = respinAvailableAt.Subtract(DateTime.Now);
            if (deltaTime.TotalSeconds <= 0)
            {
                deltaTime = new TimeSpan(0);
                availableInText.text = "Spin Now";
            }
            respinAvailableText = $"{deltaTime.Hours.ToString("00")}:{deltaTime.Minutes.ToString("00")}:{deltaTime.Seconds.ToString("00")}";
            speenWheelTimerText.text = $"{respinAvailableText}";
        }
    }
}
