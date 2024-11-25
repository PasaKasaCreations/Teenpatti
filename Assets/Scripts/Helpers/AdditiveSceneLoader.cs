using Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneLoader : MonoBehaviour
{
    [SerializeField]
    private SceneField[] additiveScenesToLoad;

    private void Awake()
    {
        foreach (SceneField scene in additiveScenesToLoad)
        {
            bool shouldLoad = true;
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                string loadedScene = SceneManager.GetSceneAt(i).name;
                if (loadedScene.Equals(scene.SceneName))
                {
                    shouldLoad = false;
                }
            }

            if (shouldLoad)
            {
                SceneManager.LoadScene(scene.SceneName, LoadSceneMode.Additive);
            }
        }
    }
}
