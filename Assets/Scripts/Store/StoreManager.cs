using API;
using Constants;
using Enums;
using Teenpatti.Data.API;
using UnityEngine;

namespace Teenpatti.Store
{
    public class StoreManager : MonoBehaviour
    {
        [Header("Store Data")]
        [SerializeField]
        private StoreData[] storeData;

        public void GetStoreItems(StoreItemType storeItemType)
        {
            APIManager.Instance.Get<GetStoreDataResponse>($"{APIConstants.GetPurchaseStoreItems}{storeItemType}",
                (response) =>
                {
                    storeData = response.data;
                },
                (error) =>
                {

                });
        }

        [ContextMenu("Purchase Coins")]
        public void PurchaseCoins()
        {
            APIManager.Instance.Post<PurchaseCoin, PurchaseCoinResponse>($"{APIConstants.PurchaseCoins}",
                new()
                {
                    purchaseBundleId = ""
                },
                (response) =>
                {

                },
                (error) =>
                {

                });
        }

        [ContextMenu("Purchase Gems")]
        public void PurchaseGems()
        {
            APIManager.Instance.Post<PurchaseGems, PurchaseGemsResponse>($"{APIConstants.PurchaseGems}",
                new()
                {
                    purchaseBundleId = ""
                },
                (response) =>
                {

                },
                (error) =>
                {

                });
        }

        [ContextMenu("Get Store Items Test")]
        public void GetStoreItemsTest()
        {
            GetStoreItems(StoreItemType.COINS);
        }
    }
}
