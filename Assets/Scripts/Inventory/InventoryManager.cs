using API;
using Constants;
using Teenpatti.Data.API;
using UnityEngine;

namespace Teenpatti.Inventories
{
    public class InventoryManager : MonoBehaviour
    {
        [Header("Inventory Data")]
        [SerializeField]
        private InventoryData[] allInventoryData;
        [SerializeField]
        private InventoryData[] ownedInventoryData;

        [ContextMenu("Get All Inventory")]
        public void GetAllInventory()
        {
            APIManager.Instance.Get<GetAllInventoryResponse>(APIConstants.GetInventory,
                (response) =>
                {
                    allInventoryData = response.data;
                },
                (error) =>
                {

                });
        }

        [ContextMenu("Get Owned Inventory")]
        public void GetOwnedInventory()
        {
            APIManager.Instance.Get<GetOwnedInventoryResponse>(APIConstants.GetOwnedInventory,
                (response) =>
                {
                    //ownedInventoryData = response.data;
                },
                (error) =>
                {

                });
        }

        public void PurchaseInventoryTrial(string inventoryItemId)
        {
            APIManager.Instance.Post<PurchaseInventoryTrial, PurchaseInventoryTrialResponse>(APIConstants.InventoryPurchaseTrial,
                new()
                {
                    inventoryItemId = inventoryItemId
                },
                (response) =>
                {

                },
                (error) =>
                {

                });
        }

        public void PurchaseInventoryPermanent(string inventoryItemId)
        {
            APIManager.Instance.Post<PurchaseInventoryPermanent, PurchaseInventoryPermanentResponse>(APIConstants.InventoryPurchasePermanent,
                new()
                {
                    inventoryItemId = inventoryItemId
                },
                (response) =>
                {

                },
                (error) =>
                {

                });
        }

        [ContextMenu("Purchase Inventory - Trial")]
        private void PurchaseInventoryTrialTest()
        {
            PurchaseInventoryTrial(allInventoryData[1].id);
        }

        [ContextMenu("Purchase Inventory - Permanent")]
        private void PurchaseInventoryPermanentTest()
        {
            PurchaseInventoryPermanent(allInventoryData[4].id);
        }
    }
}
