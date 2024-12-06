using Enums;
using Helpers;
using Newtonsoft.Json;
using ScriptableObjects.Logging;
using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace API
{
    public class APIManager : Singleton<APIManager>
    {
        [Header("Logger")]
        [SerializeField]
        private Debugger apiLogger;

        public void Get<R>(string uri, Action<R> callback = null, Action errorCallback = null)
        {
            StartCoroutine(GetRequest(uri, callback, errorCallback));
        }

        public void Post<T, R>(string uri, T data, Action<R> callback = null, Action errorCallback = null)
        {
            StartCoroutine(PostRequest(uri, data, callback, errorCallback));
        }

        public void Put<T, R>(string uri, T data, Action<R> callback = null, Action errorCallback = null, PutType putType = PutType.Put)
        {
            StartCoroutine(PutRequest(uri, data, callback, errorCallback, putType));
        }

        public void Delete(string uri, Action callback = null, Action errorCallback = null)
        {
            StartCoroutine(DeleteRequest(uri, callback, errorCallback));
        }

        private IEnumerator GetRequest<R>(string uri, Action<R> callback, Action errorCallback = null)
        {
            using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    apiLogger.Log(": Error: " + webRequest.error, LoggingType.Warning);
                    errorCallback?.Invoke();
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    apiLogger.Log(": HTTP Error: " + webRequest.error, LoggingType.Warning);
                    errorCallback?.Invoke();
                    break;
                case UnityWebRequest.Result.Success:
                    apiLogger.Log("Received: " + webRequest.downloadHandler.text);
                    R result = JsonConvert.DeserializeObject<R>(webRequest.downloadHandler.text);
                    callback?.Invoke(result);
                    break;
            }
        }

        private IEnumerator PostRequest<T, R>(string uri, T data, Action<R> callback, Action errorCallback = null)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            using UnityWebRequest webRequest = UnityWebRequest.Post(uri, jsonData, "application/json");
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                apiLogger.Log(webRequest.error, LoggingType.Warning);
                errorCallback?.Invoke();
            }
            else
            {
                apiLogger.Log(webRequest.downloadHandler.text);
                R result = JsonConvert.DeserializeObject<R>(webRequest.downloadHandler.text);
                callback?.Invoke(result);
            }
        }

        private IEnumerator PutRequest<T, R>(string uri, T data, Action<R> callback, Action errorCallback = null, PutType putType = PutType.Put)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            byte[] bodyData = Encoding.UTF8.GetBytes(jsonData);

            using UnityWebRequest webRequest = UnityWebRequest.Put(uri, bodyData);
            if(putType == PutType.Patch)
            {
                webRequest.method = "PATCH";
            }
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                apiLogger.Log(webRequest.error, LoggingType.Warning);
                errorCallback?.Invoke();
            }
            else
            {
                apiLogger.Log(webRequest.downloadHandler.text);
                R result = JsonConvert.DeserializeObject<R>(webRequest.downloadHandler.text);
                callback?.Invoke(result);
            }
        }

        private IEnumerator DeleteRequest(string uri, Action callback, Action errorCallback = null)
        {
            using UnityWebRequest webRequest = UnityWebRequest.Delete(uri);
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                apiLogger.Log(webRequest.error, LoggingType.Warning);
                errorCallback?.Invoke();
            }
            else
            {
                apiLogger.Log("Deleted");
                callback?.Invoke();
            }
        }
    }
}


