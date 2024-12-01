using Enums;
using UnityEngine;

namespace ScriptableObjects.Logging
{
    [CreateAssetMenu(fileName = "Logger", menuName = "Logger/Log")]
    public class Debugger : ScriptableObject
    {
        [SerializeField]
        private bool shouldLog = true;

        public void Log(string message, LoggingType logType = LoggingType.Normal, GameObject loggerObject = null)
        {
            if (!shouldLog) return;

            switch (logType)
            {
                case LoggingType.Normal:
                    Debug.Log(message, loggerObject);
                    break;
                case LoggingType.Warning:
                    Debug.LogWarning(message, loggerObject);
                    break;
                case LoggingType.Error:
                    Debug.LogError(message, loggerObject);
                    break;
            }
        }
    }
}
