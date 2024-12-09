using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helpers
{
    public class SceneLoaderUnloader : Singleton<SceneLoaderUnloader>
    {
        [Header("Values")]
        private float _target;
        private float _loadingValue;

        private void Update()
        {
            _loadingValue = Mathf.MoveTowards(_loadingValue, _target, Time.deltaTime);
        }

        public void Change(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(sceneName, loadSceneMode);
        }

        public void ChangeAsync(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single, float delayTime = 0)
        {
            _target = 0;
            _loadingValue = 0;
            StartCoroutine(ChangeAsyncCoroutine(sceneName, loadSceneMode, delayTime));
        }

        public IEnumerator ChangeAsyncCoroutine(string sceneName, LoadSceneMode loadSceneMode, float delayTime)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
            asyncOperation.allowSceneActivation = false;
            do
            {
                yield return new WaitForSeconds(0.1f);
                _target = asyncOperation.progress;
                yield return null;
            }
            while (asyncOperation.progress < 0.9f);

            yield return new WaitForSeconds(delayTime);
            _target = 1;
            asyncOperation.allowSceneActivation = true;
        }

        public void UnloadSceneAsync(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}
