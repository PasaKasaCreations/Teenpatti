using Helpers;
using ScriptableObjects.Data;
using ScriptableObjects.EventBus;
using System;
using TMPro;
using UnityEngine;

namespace Teenpatti.UI
{
    public class DashboardDetails : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private Timer timer;

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

        [Header("Events")]
        [SerializeField]
        private TimeSpanEventChannel SpinWheelTimeChangedEvent;

        private void OnEnable()
        {
            SpinWheelTimeChangedEvent.Event += ChangeTimer;
        }

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
            TimeSpan deltaTime = respinAvailableAt.Subtract(DateTime.Now);
            if (deltaTime.TotalSeconds <= 0)
            {
                deltaTime = new TimeSpan(0);
            }
            ChangeTimer(deltaTime);
            timer.StartTimer(deltaTime);
        }

        private void ChangeTimer(TimeSpan timeSpan)
        {
            if (timeSpan.TotalSeconds <= 0)
            {
                availableInText.text = "Spin Now";
            }
            string respinAvailableText = $"{timeSpan.Hours.ToString("00")}:{timeSpan.Minutes.ToString("00")}:{timeSpan.Seconds.ToString("00")}";
            speenWheelTimerText.text = $"{respinAvailableText}";
        }

        private void OnDisable()
        {
            SpinWheelTimeChangedEvent.Event -= ChangeTimer;
        }
    }
}
