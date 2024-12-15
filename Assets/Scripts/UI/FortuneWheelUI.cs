using API;
using Constants;
using ScriptableObjects.Data;
using Teenpatti.Data.API;
using UnityEngine;
using UnityEngine.UI;

namespace Teenpatti.UI
{
    public class FortuneWheelUI : MonoBehaviour
    {
        [Header("Fortune Wheel")]
        [SerializeField]
        private Button spinButton;

        [Header("Fortune Wheel Data")]
        [SerializeField]
        private FortuneWheelDetails fortuneWheelDetails;

        [Header("Fortune Wheel Components")]
        [SerializeField]
        private FortuneWheelDisplayUI[] fortuneWheelDisplayUIs;

        private void OnEnable()
        {
            spinButton.onClick.AddListener(Spin);

            UpdateFortuneWheelDisplay();
        }

        private void UpdateFortuneWheelDisplay()
        {
            for (int i = 0; i < fortuneWheelDetails.fortuneWheelData.Length; i++)
            {
                FortuneWheelData fortuneWheelData = fortuneWheelDetails.fortuneWheelData[i];
                fortuneWheelDisplayUIs[i].ChangeValueText(fortuneWheelData.value);
            }
        }

        private void Spin()
        {
            APIManager.Instance.Get<FortuneWheelSpinResponse>(APIConstants.SpinFortuneWheel,
            (response) =>
            {

            },
            (error) =>
            {

            });
        }

        private void OnDisable()
        {
            spinButton.onClick.RemoveAllListeners();
        }
    }
}
