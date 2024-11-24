using SocketIOClient;
using System.Collections.Generic;
using System.Net.Sockets;
using System;
using UnityEngine;
using SocketIOClient.Newtonsoft.Json;
using UnityEditor.PackageManager;
using Constants;
using Newtonsoft.Json;

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
            Uri uri = new(SocketConstants.SocketURI);
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

        public T Listen<T>(string eventName, Action callback, bool runInUnityThread)
        {
            T value = default;

            socket.On(eventName, (response) =>
            {
                value = response.GetValue<T>();

                if (callback != null)
                {
                    if (runInUnityThread) UnityThread.executeInUpdate(callback);
                    else callback.Invoke();
                }
            });

            return value;
        }

        public void Emit(string eventName, Action callback)
        {
            socket.Emit(eventName);
            callback?.Invoke();
        }

        public void Emit<T>(string eventName, T data, Action callback)
        {
            socket.Emit(eventName, data);
            callback?.Invoke();
        }

        public async void EmitAsync(string eventName, Action callback)
        {
            await socket.EmitAsync(eventName);
            callback?.Invoke();
        }

        public async void EmitAsync<T>(string eventName, T data, Action callback)
        {
            await socket.EmitAsync(eventName, data);
            callback?.Invoke();
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
