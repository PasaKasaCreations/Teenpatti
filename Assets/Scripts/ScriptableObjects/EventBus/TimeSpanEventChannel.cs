using System;
using UnityEngine;

namespace ScriptableObjects.EventBus
{
    [CreateAssetMenu(fileName = "TimeSpan EventChannel", menuName = "Events/TimeSpan EventChannel")]
    public class TimeSpanEventChannel : GenericEventChannelSO<TimeSpan>
    {
    }
}
