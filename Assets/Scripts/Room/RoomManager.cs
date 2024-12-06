using Constants;
using Newtonsoft.Json;
using ScriptableObjects.EventBus;
using ScriptableObjects.Logging;
using Socket;
using System.Collections.Generic;
using System.Linq;
using Teenpatti.Data.Socket;
using UnityEngine;


namespace Teenpatti.RoomScripts
{
    public class RoomManager : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField]
        private VoidEventChannel SocketConnectedEvent;
        [SerializeField]
        private PlayerEventChannel PlayerJoinedEvent;
        [SerializeField]
        private RoomEventChannel RoomJoinedEvent;

        [Header("Room Data")]
        [SerializeField]
        private List<Player> players = new();

        [Header("Logger")]
        [SerializeField]
        private Debugger roomDebugger;

        private void OnEnable()
        {
            SocketConnectedEvent.Event += OnSocketConnected;
        }

        private void OnSocketConnected()
        {
            SocketManager.Instance.Listen<Room>(SocketEvents.GameRoomJoinResponse, true, (room) =>
            {
                roomDebugger.Log(JsonConvert.SerializeObject(room));
                RoomJoinedEvent.Raise(room);
            });
            SocketManager.Instance.Listen<Room>(SocketEvents.GameRoomLeaveResponse, true, (room) =>
            {
                roomDebugger.Log(JsonConvert.SerializeObject(room));
            });
            SocketManager.Instance.Listen<RoomData>(SocketEvents.GameRoomUpdateResponse, true, (roomData) =>
            {
                roomDebugger.Log(JsonConvert.SerializeObject(roomData));
                foreach (Player roomPlayer in roomData.players)
                {
                    Player existingPlayer = null;
                    if(players.Count > 0)
                    {
                        existingPlayer = players.FirstOrDefault(player => player.id == roomPlayer.id);
                    }
                    if(existingPlayer == null)
                    {
                        players.Add(roomPlayer);
                        PlayerJoinedEvent.Raise(roomPlayer);
                    }
                }
            });
            SocketManager.Instance.Listen<Room>(SocketEvents.GameRoomClosedResponse, true, (room) =>
            {
                roomDebugger.Log(JsonConvert.SerializeObject(room));
            });
        }

        [ContextMenu("Join Room")]
        public void JoinRoom()
        {
            SocketManager.Instance.Emit<Player>(SocketEvents.GameRoomJoin, new Player()
            {
                id = "1",
                name = "Shreedesh",
                avatar = "https://via.placeholder.com/50",
                balance = 2000,
            }, () =>
            {
                roomDebugger.Log("Joining Room...");
            });
        }

        [ContextMenu("Leave Room")]
        public void LeaveRoom()
        {
            SocketManager.Instance.Emit(SocketEvents.GameRoomLeave, new Player()
            {
                id = "1",
            },
            () =>
            {
                roomDebugger.Log("Leaving Room...");
            });
        }

        private void OnDisable()
        {
            SocketConnectedEvent.Event -= OnSocketConnected;
        }
    }
}