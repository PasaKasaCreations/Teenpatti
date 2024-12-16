using ScriptableObjects.EventBus;
using System;
using System.Collections;
using UnityEngine;

namespace Helpers
{
    public class Timer : MonoBehaviour
    {
        [Header("Timer Values")]
        private bool _isTimerRunning;

        [Header("Events")]
        [SerializeField]
        private TimeSpanEventChannel SpinWheelTimeChangedEvent;
        [SerializeField]
        private VoidEventChannel TimerCompletedEvent;

        [Header("Coroutines")]
        private Coroutine _startTimerCoroutine;

        public void StartTimer(TimeSpan startTime)
        {
            if (_startTimerCoroutine != null) StopCoroutine(_startTimerCoroutine);
            _startTimerCoroutine = StartCoroutine(StartTimerCoroutine(startTime));
        }

        private IEnumerator StartTimerCoroutine(TimeSpan startTime)
        {
            TimeSpan time = startTime;
            _isTimerRunning = true;

            while (_isTimerRunning)
            {
                yield return new WaitForSeconds(1);
                time = time.Subtract(TimeSpan.FromSeconds(1));
                if (time.Seconds <= 0)
                {
                    _isTimerRunning = false;
                    TimerCompletedEvent.Raise();
                }
                else
                {
                    SpinWheelTimeChangedEvent.Raise(time);
                }
            }
        }

        [ContextMenu("Test Start Timer")]
        private void TestStartTimer()
        {
            StartTimer(new TimeSpan(0, 0, 5));
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}