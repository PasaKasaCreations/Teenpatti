using System;
using UnityEngine;

namespace ScriptableObjects.EventBus
{
    public abstract class GenericEventChannelSO<T> : ScriptableObject
    {
        public Action<T> Event;

        public void Raise(T data)
        {
            Event?.Invoke(data);    
        }
    }
}
