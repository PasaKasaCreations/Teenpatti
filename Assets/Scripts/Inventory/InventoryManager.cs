using API;
using Constants;
using Teenpatti.Data.API;
using UnityEngine;

namespace Teenpatti.Inventories
{
    public class InventoryManager : MonoBehaviour
    {
        [ContextMenu("Get All Inventory")]
        public void GetAllInventory()
        {
            APIManager.Instance.Get<GetAllInventoryResponse>(APIConstants.GetInventory,
                (response) =>
                {

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

                },
                (error) =>
                {

                });
        }
    }
}
