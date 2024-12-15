using Teenpatti.Data.API;
using UnityEngine;

namespace ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "Fortune Wheel Details", menuName = "Data/Fortune Wheel Details")]
    public class FortuneWheelDetails : ScriptableObject
    {
        public FortuneWheelData[] fortuneWheelData;

        public void SetFortuneWheelData(FortuneWheelData[] fortuneWheelData)
        {
            this.fortuneWheelData = fortuneWheelData;
        }
    }
}
