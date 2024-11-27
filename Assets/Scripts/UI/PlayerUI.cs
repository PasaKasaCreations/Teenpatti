using TMPro;
using UnityEngine;

namespace Teenpatti.UI
{
    public class PlayerUI : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private TMP_Text nameText;
        [SerializeField]
        private TMP_Text balanceText;

        public void SetName(string name) => nameText.text = name;
        public void SetBalance(string balance) => balanceText.text = balance;
    }
}
