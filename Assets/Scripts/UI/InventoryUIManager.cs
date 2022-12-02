using UnityEngine;

namespace UI
{
    public class InventoryUIManager : MonoBehaviour
    {
        public GameObject InventoryRowPrefab;
        private GameObject _inventoryUI;

        void Start()
        {
            _inventoryUI = GameObject.Find("InventoryUI");
            HandleInventoryUpdate();
        }

        void HandleInventoryUpdate()
        {
            var inventoryRow = Instantiate(InventoryRowPrefab, _inventoryUI.transform.position, Quaternion.identity, _inventoryUI.transform);
        }
    }
}