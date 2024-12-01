using Enums;
using Helpers;
using Newtonsoft.Json;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace API
{
    public class APIHandler : Singleton<APIHandler>
    {
        public void Get(string uri)
        {
            StartCoroutine(GetRequest(uri));
        }

        public void Post<T>(string uri, T data)
        {
            StartCoroutine(PostRequest(uri, data));
        }

        public void Put<T>(string uri, T data)
        {
            StartCoroutine(PutRequest(uri, data));
        }

        public void Delete(string uri)
        {
            StartCoroutine(DeleteRequest(uri));
        }

        private IEnumerator GetRequest(string uri)
        {
            using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Received: " + webRequest.downloadHandler.text);
                    break;
            }
        }

        private IEnumerator PostRequest<T>(string uri, T data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            using UnityWebRequest www = UnityWebRequest.Post(uri, jsonData, "application/json");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }

        private IEnumerator PutRequest<T>(string uri, T data, PutType putType = PutType.Put)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            byte[] bodyData = Encoding.UTF8.GetBytes(jsonData);

            using UnityWebRequest www = UnityWebRequest.Put(uri, bodyData);
            if(putType == PutType.Patch)
            {
                www.method = "PATCH";
            }
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }

        private IEnumerator DeleteRequest(string uri)
        {
            using UnityWebRequest www = UnityWebRequest.Delete(uri);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Deleted");
            }
        }

        [ContextMenu("Test Get")]
        private void TestGet()
        {
            Get("https://fakestoreapi.com/products/1");
        }

        [ContextMenu("Test Post")]
        private void TestPost()
        {
            Post("https://fakestoreapi.com/auth/login", new Auth()
            {
                username = "mor_2314",
                password = "83r5^_",
            });
        }

        [ContextMenu("Test Put")]
        private void TestPut()
        {
            Put("https://fakestoreapi.com/products/7", new Product()
            {
                title = "Hello",
                price = 11.2f,
            });
        }

        [ContextMenu("Test Delete")]
        private void TestDelete()
        {
            Delete("https://fakestoreapi.com/users/6");
        }

        private class Auth
        {
            public string username;
            public string password;
        }

        private class Product
        {
            public string title;
            public float price;
        }
    }
}


