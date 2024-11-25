using System;
using UnityEngine;

namespace ScriptableObjects.EventBus
{
    [CreateAssetMenu(fileName = "Void EventChannel", menuName = "Events/Void EventChannel")]
    public class VoidEventChannel : ScriptableObject
    {
        public Action Event;

        public void Raise()
        {
            Event?.Invoke();
        }
    }
}
