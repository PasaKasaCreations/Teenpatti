using ScriptableObjects.Data;
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

        [Header("Player Details")]
        [SerializeField]
        private PlayerDetails playerDetails;

        private void Start()
        {
            UpdateLevelText(playerDetails.level);
            UpdateCoinText(playerDetails.coins);
            UpdateGemText(playerDetails.gems);
        }

        private void UpdateLevelText(int level) => levelText.text = $"Level {level}";

        private void UpdateCoinText(string coins) => coinText.text = $"{coins}";

        private void UpdateGemText(int gems) => gemText.text = $"{gems}";
    }
}
