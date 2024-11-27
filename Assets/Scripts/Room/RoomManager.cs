using Newtonsoft.Json;
using ScriptableObjects.EventBus;
using ScriptableObjects.Logging;
using Socket;
using System.Collections.Generic;
using System.Linq;
using Teenpatti.Data;
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
            SocketManager.Instance.Listen<Room>("gameroom:join-response", true, (room) =>
            {
                roomDebugger.Log(JsonConvert.SerializeObject(room));
            });
            SocketManager.Instance.Listen<RoomData>("gameroom:update-response", true, (roomData) =>
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
        }

        [ContextMenu("Join Room")]
        private void JoinRoom()
        {
            SocketManager.Instance.Emit<PlayerData>("gameroom:join", new PlayerData()
            {
                id = 1,
                name = "Shreedesh",
                avatar = "https://via.placeholder.com/50",
                balance = 2000,
            }, () =>
            {
                roomDebugger.Log("Room Joined");
            });
        }

        private void OnDisable()
        {
            SocketConnectedEvent.Event -= OnSocketConnected;
        }

        public class PlayerData
        {
            public int id;
            public string name;
            public string avatar;
            public float balance;
        }
    }
}