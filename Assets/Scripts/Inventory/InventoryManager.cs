using API;
using Constants;
using Enums;
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
        private OwnedInventoryData[] ownedInventoryData;

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

        public void GetOwnedInventory(InventoryType inventoryType)
        {
            APIManager.Instance.Get<GetOwnedInventoryResponse>($"{APIConstants.GetOwnedInventory}{inventoryType}",
                (response) =>
                {
                    ownedInventoryData = response.data;
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

        [ContextMenu("Get Owned Inventory Test")]
        private void GetOwnedInventoryTest()
        {
            GetOwnedInventory(InventoryType.FRAME);
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
