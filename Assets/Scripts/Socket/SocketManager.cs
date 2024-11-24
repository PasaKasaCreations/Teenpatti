using SocketIOClient;
using System.Collections.Generic;
using System.Net.Sockets;
using System;
using UnityEngine;
using SocketIOClient.Newtonsoft.Json;
using UnityEditor.PackageManager;

namespace Socket
{
    public class SocketManager : MonoBehaviour
    {
        private SocketIOUnity socket;

        private void Start()
        {
            Initialize();
        }

        private async void Initialize()
        {
            Uri uri = new("http://localhost:3000");
            socket = new SocketIOUnity(uri, new SocketIOOptions
            {
                Query = new Dictionary<string, string>
                {
                    {"token", "UNITY" }
                },
                Transport = SocketIOClient.Transport.TransportProtocol.WebSocket,
            });

            socket.JsonSerializer = new NewtonsoftJsonSerializer();
            socket.OnConnected += OnConnected;
            socket.OnDisconnected += OnDisconnected;
            socket.OnError += OnError;
            socket.OnReconnectAttempt += OnReconnectAttempt; ;
            socket.OnPing += OnPing;
            socket.OnReconnected += OnReconnected;
            socket.OnReconnectError += OnReconnectedError; ;
            socket.OnReconnectFailed += OnReconnectFailed; 

            await socket.ConnectAsync();
        }

        private void OnConnected(object sender, EventArgs e)
        {
            Debug.Log("Socket Connected!!!");
        }

        private void OnDisconnected(object sender, string e)
        {
            Debug.Log("Socket DisConnected!!!");
        }

        private void OnError(object sender, string e)
        {
            Debug.Log("Socket Error!!!");
        }

        private void OnPing(object sender, EventArgs e)
        {
            Debug.Log("Pinging!!!");
        }

        private void OnReconnectAttempt(object sender, int e)
        {
            Debug.Log("Reconnect Attempt!!!");
        }

        private void OnReconnected(object sender, int e)
        {
            Debug.Log("Reconnected!!!");
        }

        private void OnReconnectedError(object sender, Exception e)
        {
            Debug.Log("Reconnect Error!!!");
        }

        private void OnReconnectFailed(object sender, EventArgs e)
        {
            Debug.Log("Reconnect Failed!!!");
        }

        private async void OnDisable()
        {
            socket.OnConnected -= OnConnected;
            socket.OnDisconnected -= OnDisconnected;
            socket.OnError -= OnError;
            socket.OnReconnectAttempt -= OnReconnectAttempt; ;
            socket.OnPing -= OnPing;
            socket.OnReconnected -= OnReconnected;
            socket.OnReconnectError -= OnReconnectedError; ;
            socket.OnReconnectFailed -= OnReconnectFailed;

            await socket.DisconnectAsync();
        }
    }
}
