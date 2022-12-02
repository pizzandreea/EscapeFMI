using UnityEngine;

namespace UI
{
    public class InventoryUIManager : MonoBehaviour
    {
        public GameObject InventoryRowPrefab;
        private GameObject _inventoryUI;

        public void Start()
        {
            _inventoryUI = GameObject.Find("InventoryUI");
            CreateInventoryUI();
        }

        private void HandleInventoryUpdate()
        {
            ClearInventoryUI();
            CreateInventoryUI();
        }

        private void ClearInventoryUI()
        {
            foreach (Transform child in _inventoryUI.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void CreateInventoryUI()
        {
            Instantiate(
                InventoryRowPrefab, _inventoryUI.transform.position, Quaternion.identity, _inventoryUI.transform
            );
        }
    }
}