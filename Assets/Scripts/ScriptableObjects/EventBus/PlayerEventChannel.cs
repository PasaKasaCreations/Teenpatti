using Teenpatti.Data.Socket;
using UnityEngine;

namespace ScriptableObjects.EventBus
{
    [CreateAssetMenu(fileName = "Player EventChannel", menuName = "Events/Player EventChannel")]
    public class PlayerEventChannel : GenericEventChannelSO<Player>
    {

    }
}
