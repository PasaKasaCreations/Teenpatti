using ScriptableObjects.EventBus;
using Teenpatti.Data;
using UnityEngine;

namespace Teenpatti.UI
{
    public class RoomUI : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField]
        private PlayerUI playerUIPrefab;

        [Header("Components")]
        [SerializeField]
        private Transform playerUIParentTransform;

        [Header("Events")]
        [SerializeField]
        private PlayerEventChannel PlayerJoinedEvent;

        private void OnEnable()
        {
            PlayerJoinedEvent.Event += OnPlayerJoined;
        }

        private void OnPlayerJoined(Player player)
        {
            PlayerUI playerUI = Instantiate(playerUIPrefab, playerUIParentTransform);
            playerUI.SetName($"Name: {player.name}");
            playerUI.SetBalance($"Balance: {player.balance.ToString()}");
        }

        private void OnDisable()
        {
            PlayerJoinedEvent.Event -= OnPlayerJoined;
        }
    }
}
