using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helpers
{
    public class SceneChanger : Singleton<SceneChanger>
    {
        public void Change(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(sceneName, loadSceneMode);
        }

        public void ChangeAsync(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single, float delayTime = 1)
        {
            StartCoroutine(ChangeAsyncCoroutine(sceneName, loadSceneMode, delayTime));
        }

        public IEnumerator ChangeAsyncCoroutine(string sceneName, LoadSceneMode loadSceneMode, float delayTime)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
            asyncOperation.allowSceneActivation = false;
            do
            {
                yield return new WaitForSeconds(0.1f);
                print(asyncOperation.progress);
                yield return null;
            }
            while (asyncOperation.progress < 0.9f);

            yield return new WaitForSeconds(delayTime);
            asyncOperation.allowSceneActivation = true;
        }
    }
}
