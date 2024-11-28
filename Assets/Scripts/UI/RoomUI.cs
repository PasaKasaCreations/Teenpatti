using ScriptableObjects.EventBus;
using Teenpatti.Data;
using TMPro;
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
        [SerializeField]
        private TMP_Text roomIdText;

        [Header("Events")]
        [SerializeField]
        private PlayerEventChannel PlayerJoinedEvent;
        [SerializeField]
        private RoomEventChannel RoomJoinedEvent;

        private void OnEnable()
        {
            PlayerJoinedEvent.Event += OnPlayerJoined;
            RoomJoinedEvent.Event += OnRoomJoined;
        }

        private void OnPlayerJoined(Player player)
        {
            PlayerUI playerUI = Instantiate(playerUIPrefab, playerUIParentTransform);
            playerUI.SetName($"Name: {player.name}");
            playerUI.SetBalance($"Balance: {player.balance.ToString()}");
        }

        private void OnRoomJoined(Room room)
        {
            roomIdText.text = room.roomId;
        }

        private void OnDisable()
        {
            PlayerJoinedEvent.Event -= OnPlayerJoined;
            RoomJoinedEvent.Event -= OnRoomJoined;
        }
    }
}
