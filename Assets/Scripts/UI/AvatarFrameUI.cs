using ScriptableObjects.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Teenpatti.UI
{
    public class AvatarFrameUI : MonoBehaviour
    {
        [Header("Player Data")]
        [SerializeField]
        private Image avatarImage;
        [SerializeField]
        private Image frameImage;

        [Header("Player Data")]
        [SerializeField]
        private PlayerDetails playerDetails;

        private void Start()
        {
            ChangeAvatar();
        }

        private void ChangeAvatar()
        {
            avatarImage.sprite = playerDetails.avatar;
            frameImage.sprite = playerDetails.frame;
        }
    }
}
