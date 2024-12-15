using API;
using Constants;
using ScriptableObjects.Data;
using Teenpatti.Data.API;
using UnityEngine;
using UnityEngine.UI;

namespace Teenpatti.UI
{
    public class FortuneWheelButton : MonoBehaviour
    {
        [SerializeField]
        private Button spinwheelButton;

        [Header("Canvases")]
        [SerializeField]
        private Canvas spinWheelCanvas;

        [Header("Fortune Wheel Details")]
        [SerializeField]
        private FortuneWheelDetails fortuneWheelDetails;
        private void OnEnable()
        {
            spinwheelButton.onClick.AddListener(ShowSpinWheel);
        }

        private void ShowSpinWheel()
        {
            APIManager.Instance.Get<FortuneWheelResponse>(APIConstants.GetFortuneWheelValues,
            (response) =>
            {
                fortuneWheelDetails.SetFortuneWheelData(response.data);
                spinWheelCanvas.gameObject.SetActive(true);
            },
            (error) =>
            {

            });
        }

        private void OnDisable()
        {
            spinwheelButton.onClick.RemoveAllListeners();
        }
    }
}
