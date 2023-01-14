using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryUIManager : MonoBehaviour
    {
        private GameObject _inventoryUI;

        private void Awake()
        {
            _inventoryUI = GameObject.Find("InventoryUI");
        }

        private void Start()
        {
            CreateInventoryUI();
        }

        private void Update()
        {
            if (GameManager.Instance.Inventory.shouldUpdateUI)
            {
                Debug.Log("update");
                HandleInventoryUpdate();
                GameManager.Instance.Inventory.shouldUpdateUI = false;
            }
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
                if (child != null && child.gameObject != null)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

        private void CreateInventoryUI()
        {
            var rowIndex = 0;
            foreach (var itemName in GameManager.Instance.Inventory.GetItems().Keys)
            {
                var item = GameManager.Instance.Inventory.GetItems()[itemName];

                CreateInventoryUIRow(item.Sprite, item.Quantity, rowIndex);

                rowIndex++;
            }
        }

        private void CreateInventoryUIRow(Sprite sprite, int quantity, int rowIndex)
        {
            var prefabRectTransform = GameAssets.instance.pfInventoryUIRow.GetComponent<RectTransform>();
            var prefabPosition = _inventoryUI.transform.position;

            var rowPosition = new Vector3(prefabPosition.x,
                prefabPosition.y - rowIndex * prefabRectTransform.rect.height, prefabPosition.z
            );

            var inventoryUIRow = Instantiate(
                GameAssets.instance.pfInventoryUIRow, rowPosition, Quaternion.identity, _inventoryUI.transform
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