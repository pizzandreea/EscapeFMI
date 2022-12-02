using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        public void HandleInventoryUpdate()
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
            int rowIndex = 0;
            foreach (var itemName in GameManager.Instance.Inventory.Items.Keys)
            {
                var item = GameManager.Instance.Inventory.Items[itemName];

                CreateInventoryUIRow(item.Sprite, item.Quantity, rowIndex);

                rowIndex++;
            }
        }

        private void CreateInventoryUIRow(Sprite sprite, int quantity, int rowIndex)
        {
            var inventoryUIRow = Instantiate(
                InventoryRowPrefab, _inventoryUI.transform.position, Quaternion.identity, _inventoryUI.transform
            );

            foreach (Transform transform in inventoryUIRow.transform)
            {
                if (transform.name == "Sprite")
                {
                    var image = transform.GetComponent<Image>();
                    image.sprite = sprite;
                }
                else if (transform.name == "Text")
                {
                    var text = transform.GetComponent<TextMeshProUGUI>();
                    text.text = "x" + quantity;
                }
            }
        }
    }
}