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

        [Header("Fortune Wheel Rotation")]
        [SerializeField]
        private Transform spinWheelTransform;
        [SerializeField]
        private float rotationTime = 2;
        [SerializeField]
        private float showRotationTime = 3;
        [SerializeField]
        private int rotateRepeatation = 3;

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
                RotateWheel(response.data.winIndex);
            },
            (error) =>
            {

            });
        }

        private void RotateWheel(int goToIndex)
        {
            float angle = 360f / fortuneWheelDisplayUIs.Length;

            LeanTween.rotateAround(spinWheelTransform.gameObject, Vector3.forward, angle * fortuneWheelDisplayUIs.Length, rotationTime)
                .setRepeat(rotateRepeatation)
                .setOnComplete(() =>
                {
                    LeanTween.rotateAround(spinWheelTransform.gameObject, Vector3.forward, angle * goToIndex, showRotationTime)
                    .setEaseOutBounce();
                    LeanTween.cancel(gameObject);
                });
        }

        [ContextMenu("Test Rotate Wheel")]
        private void TestRotateWheel()
        {
            RotateWheel(3);
        }

        private void OnDisable()
        {
            spinButton.onClick.RemoveAllListeners();

            StopAllCoroutines();
        }
    }
}
