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

        public void ChangeAsync(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
        }
    }
}
