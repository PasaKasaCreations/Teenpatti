using Teenpatti.Data;
using UnityEngine;

namespace ScriptableObjects.EventBus
{
    [CreateAssetMenu(fileName = "Room EventChannel", menuName = "Events/Room EventChannel")]
    public class RoomEventChannel : GenericEventChannelSO<Room>
    {

    }
}