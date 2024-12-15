using API;
using Constants;
using ScriptableObjects.Data;
using ScriptableObjects.Logging;
using Teenpatti.Data.API;
using UnityEngine;

namespace Teenpatti.FortuneWheel
{
    public class FortuneWheelManager : MonoBehaviour
    {
        [Header("Fortune Wheel Details")]
        [SerializeField]
        private FortuneWheelDetails fortuneWheelDetails;    

        [Header("Logger")]
        [SerializeField]
        private Debugger apiLogger;

        [ContextMenu("Get Fortune Wheel Values")]
        private void GetFortuneWheelValues()
        {
            APIManager.Instance.Get<FortuneWheelResponse>(APIConstants.GetFortuneWheelValues,
            (response) =>
            {
                fortuneWheelDetails.SetFortuneWheelData(response.data);
            },
            (error) =>
            {
                apiLogger.Log(error.message, Enums.LoggingType.Warning);
            });
        }

        [ContextMenu("Spin Fortune Wheel")]
        private void SpinFortuneWheel()
        {
            APIManager.Instance.Get<FortuneWheelSpinResponse>(APIConstants.SpinFortuneWheel,
            (response) =>
            {

            },
            (error) =>
            {
                apiLogger.Log(error.message, Enums.LoggingType.Warning);
            });
        }
    }
}
