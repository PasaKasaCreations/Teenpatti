using UnityEngine;

namespace Helpers
{
    [System.Serializable]
    public class SceneField
    {
        [SerializeField]
        private Object scene;
        [SerializeField]
        private string sceneName = "";
        public string SceneName => sceneName;

        public static implicit operator string(SceneField sceneField)
        {
            return sceneField.SceneName;
        }
    }
}

