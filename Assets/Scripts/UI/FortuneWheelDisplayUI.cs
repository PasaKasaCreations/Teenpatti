using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Teenpatti.UI
{
    public class FortuneWheelDisplayUI : MonoBehaviour
    {
        [SerializeField]
        private Image displayImage;
        [SerializeField]
        private TMP_Text valueText;

        public void ChangeDisplayImage()
        {

        }

        public void ChangeValueText(string value)
        {
            valueText.text = value;
        }
    }
}
