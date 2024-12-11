using API;
using Constants;
using ScriptableObjects.Logging;
using Teenpatti.Data.API;
using UnityEngine;

namespace Teenpatti.Offers
{
    public class OfferManager : MonoBehaviour
    {
        [Header("Offer Data")]
        [SerializeField]
        private OfferData[] offerData;

        [Header("Logger")]
        [SerializeField]
        private Debugger apiLogger;

        [ContextMenu("Get Offers")]
        private void GetDailyRewards()
        {
            APIManager.Instance.Get<OfferResponse>(APIConstants.GetOffers,
            (response) =>
            {
                offerData = response.data;
            },
            (error) =>
            {
                apiLogger.Log(error.message, Enums.LoggingType.Warning);
            });
        }
    }
}
