using SocketIOClient;
using System;
using UnityEngine;
using SocketIOClient.Newtonsoft.Json;
using Constants;
using Helpers;
using Teenpatti.Data;
using ScriptableObjects.EventBus;


namespace Socket
{
    public class SocketManager : Singleton<SocketManager>
    {
        [Header("Socket")]
        private SocketIOUnity _socket;

        [Header("Events")]
        [SerializeField]
        private VoidEventChannel SocketConnectedEvent;

        private void Start()
        {
            Initialize();
        }

        private async void Initialize()
        {
            Uri uri = new(SocketConstants.SocketURI);
           
            SocketIOOptions socketOptions = new SocketIOOptions
            {
                Path = "/socket.io",
                Auth = new Auth()
                {
                    token = SocketConstants.Token,
                },
                Transport = SocketIOClient.Transport.TransportProtocol.WebSocket,
            };
            _socket = new SocketIOUnity(uri, socketOptions);

            _socket.JsonSerializer = new NewtonsoftJsonSerializer();
            _socket.OnConnected += OnConnected;
            _socket.OnDisconnected += OnDisconnected;
            _socket.OnError += OnError;
            _socket.OnReconnectAttempt += OnReconnectAttempt; ;
            _socket.OnPing += OnPing;
            _socket.OnReconnected += OnReconnected;
            _socket.OnReconnectError += OnReconnectedError; ;
            _socket.OnReconnectFailed += OnReconnectFailed;

            await _socket.ConnectAsync();
        }

        private void OnConnected(object sender, EventArgs e)
        {
            SocketConnectedEvent.Raise();
            Debug.Log("Socket Connected!!!");
        }

        private void OnDisconnected(object sender, string e)
        {
            Debug.Log("Socket DisConnected!!!");
        }

        private void OnError(object sender, string e)
        {
            Debug.Log($"Socket Error!!! {e}");
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

        public void Listen<T>(string eventName, bool runInUnityThread = false, Action<T> callback = null)
        {
            _socket.On(eventName, (response) =>
            {
                T value = response.GetValue<T>();

                if (callback != null)
                {
                    if (runInUnityThread) UnityThread.executeInUpdate(() => callback.Invoke(value));
                    else callback.Invoke(value);
                }
            });
        }

        public void Emit(string eventName, Action callback = null)
        {
            _socket.Emit(eventName);
            callback?.Invoke();
        }

        public void Emit<T>(string eventName, T data, Action callback = null)
        {
            _socket.Emit(eventName, data);
            callback?.Invoke();
        }

        public async void EmitAsync(string eventName, Action callback = null)
        {
            await _socket.EmitAsync(eventName);
            callback?.Invoke();
        }

        public async void EmitAsync<T>(string eventName, T data, Action callback = null)
        {
            await _socket.EmitAsync(eventName, data);
            callback?.Invoke();
        }

        private async void OnDisable()
        {
            _socket.OnConnected -= OnConnected;
            _socket.OnDisconnected -= OnDisconnected;
            _socket.OnError -= OnError;
            _socket.OnReconnectAttempt -= OnReconnectAttempt; ;
            _socket.OnPing -= OnPing;
            _socket.OnReconnected -= OnReconnected;
            _socket.OnReconnectError -= OnReconnectedError; ;
            _socket.OnReconnectFailed -= OnReconnectFailed;

            await _socket.DisconnectAsync();
        }
    }
}
