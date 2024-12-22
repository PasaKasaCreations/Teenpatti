using Enums;
using Helpers;
using Newtonsoft.Json;
using ScriptableObjects.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Teenpatti;
using Teenpatti.Data;
using UnityEngine;
using UnityEngine.Networking;

namespace API
{
    public class APIManager : Singleton<APIManager>
    {
        [Header("Timeout")]
        [SerializeField]
        private int timeoutSeconds = 10;
        private bool _isTokenRefreshing;

        [Header("Logger")]
        [SerializeField]
        private Debugger apiLogger;

        [Header("Default Values")]
        private Dictionary<string, string> headers => new()
        {
            {"Authorization", $"Bearer {Authenticator.Instance.GetAccessToken()}"}
        };

        public void Get<R>(string uri, Action<R> callback = null, Action<Error> errorCallback = null, Dictionary<string, string> headers = null)
        {
            StartCoroutine(GetRequest(uri, headers == null ? this.headers : headers, callback, errorCallback));
        }

        public void Post<T, R>(string uri, T data, Action<R> callback = null, Action<Error> errorCallback = null, Dictionary<string, string> headers = null)
        {
            StartCoroutine(PostRequest(uri, data, headers == null ? this.headers : headers, callback, errorCallback));
        }

        public void Put<T, R>(string uri, T data, Action<R> callback = null, Action<Error> errorCallback = null, PutType putType = PutType.Put)
        {
            StartCoroutine(PutRequest(uri, data, callback, errorCallback, putType));
        }

        public void Delete(string uri, Action callback = null, Action<Error> errorCallback = null)
        {
            StartCoroutine(DeleteRequest(uri, callback, errorCallback));
        }

        private IEnumerator GetRequest<R>(string uri, Dictionary<string, string> headers, Action<R> callback, Action<Error> errorCallback = null)
        {
            using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
            if(headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    webRequest.SetRequestHeader(header.Key, header.Value);
                }
            }
            webRequest.timeout = timeoutSeconds;
            yield return webRequest.SendWebRequest();

            if(webRequest.result != UnityWebRequest.Result.Success)
            {
                if(webRequest.responseCode == 401)
                {
                    IEnumerator getEnumerator = GetRequest(uri, headers, callback, errorCallback);
                    RefreshToken(getEnumerator);
                }

                if (!_isTokenRefreshing)
                {
                    apiLogger.Log(webRequest.downloadHandler.text, LoggingType.Warning);
                    Error error = JsonConvert.DeserializeObject<Error>(webRequest.downloadHandler.text);
                    errorCallback?.Invoke(error);
                }
            }
            else
            {
                apiLogger.Log(webRequest.downloadHandler.text);
                R result = JsonConvert.DeserializeObject<R>(webRequest.downloadHandler.text);
                callback?.Invoke(result);
            }
        }

        private IEnumerator PostRequest<T, R>(string uri, T data, Dictionary<string, string> headers = null, Action<R> callback = null, Action<Error> errorCallback = null)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            using UnityWebRequest webRequest = UnityWebRequest.Post(uri, jsonData, "application/json");
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    webRequest.SetRequestHeader(header.Key, header.Value);
                }
            }
            webRequest.timeout = timeoutSeconds;
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                if (webRequest.responseCode == 401)
                {
                    IEnumerator postEnumerator = PostRequest(uri, data, headers, callback, errorCallback);
                    RefreshToken(postEnumerator);
                }

                if (!_isTokenRefreshing)
                {
                    apiLogger.Log(webRequest.downloadHandler.text, LoggingType.Warning);
                    Error error = JsonConvert.DeserializeObject<Error>(webRequest.downloadHandler.text);
                    errorCallback?.Invoke(error);
                }
            }
            else
            {
                apiLogger.Log(webRequest.downloadHandler.text);
                R result = JsonConvert.DeserializeObject<R>(webRequest.downloadHandler.text);
                callback?.Invoke(result);
            }
        }

        private IEnumerator PutRequest<T, R>(string uri, T data, Action<R> callback, Action<Error> errorCallback = null, PutType putType = PutType.Put)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            byte[] bodyData = Encoding.UTF8.GetBytes(jsonData);

            using UnityWebRequest webRequest = UnityWebRequest.Put(uri, bodyData);
            webRequest.timeout = timeoutSeconds;
            if (putType == PutType.Patch)
            {
                webRequest.method = "PATCH";
            }
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                if (webRequest.responseCode == 401)
                {
                    IEnumerator piuEnumerator = PutRequest(uri, data, callback, errorCallback);
                    RefreshToken(piuEnumerator);
                }

                if(!_isTokenRefreshing)
                {
                    apiLogger.Log(webRequest.error, LoggingType.Warning);
                    Error error = JsonConvert.DeserializeObject<Error>(webRequest.downloadHandler.text);
                    errorCallback?.Invoke(error);
                    errorCallback?.Invoke(error);
                }
            }
            else
            {
                apiLogger.Log(webRequest.downloadHandler.text);
                R result = JsonConvert.DeserializeObject<R>(webRequest.downloadHandler.text);
                callback?.Invoke(result);
            }
        }

        private IEnumerator DeleteRequest(string uri, Action callback, Action<Error> errorCallback = null)
        {
            using UnityWebRequest webRequest = UnityWebRequest.Delete(uri);
            webRequest.timeout = timeoutSeconds;
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                if (webRequest.responseCode == 401)
                {
                    IEnumerator deleteEnumerator = DeleteRequest(uri, callback, errorCallback);
                    RefreshToken(deleteEnumerator);
                }

                if (!_isTokenRefreshing)
                {
                    apiLogger.Log(webRequest.error, LoggingType.Warning);
                    Error error = JsonConvert.DeserializeObject<Error>(webRequest.downloadHandler.text);
                    errorCallback?.Invoke(error);
                    errorCallback?.Invoke(error);
                }
            }
            else
            {
                apiLogger.Log("Deleted");
                callback?.Invoke();
            }
        }

        private void RefreshToken(IEnumerator enumerator)
        {
            if (!_isTokenRefreshing)
            {
                _isTokenRefreshing = true;
                Authenticator.Instance.RefreshLogin(() =>
                {
                    StartCoroutine(RefreshRecallCoroutine(enumerator));
                });
            }
        }

        private IEnumerator RefreshRecallCoroutine(IEnumerator recallCoroutine)
        {
            yield return StartCoroutine(recallCoroutine);
            _isTokenRefreshing = false;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}


