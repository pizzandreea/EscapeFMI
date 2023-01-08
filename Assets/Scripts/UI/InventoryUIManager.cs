using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryUIManager : MonoBehaviour
    {
        public GameObject InventoryUIRowPrefab;
        private GameObject _inventoryUI;

        public void Start()
        {
           
                _inventoryUI = GameObject.Find("InventoryUI");
                CreateInventoryUI();
            
            
        }

        public void HandleInventoryUpdate()
        {
            Debug.Log(InventoryUIRowPrefab);
            Debug.Log(_inventoryUI);
            if(InventoryUIRowPrefab != null && _inventoryUI != null)
            {
                //ClearInventoryUI();
                CreateInventoryUI();
            }
            
        }

        private void ClearInventoryUI()
        {
            foreach (Transform child in _inventoryUI.transform)
            {
                if( child!= null && child.gameObject != null)
                {
                    //Destroy(child.gameObject);
                    child.gameObject.SetActive(false);
                }
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
            var prefabRectTransform = InventoryUIRowPrefab.GetComponent<RectTransform>();
            var prefabPosition = _inventoryUI.transform.position;
            
            var rowPosition = new Vector3(prefabPosition.x,
                prefabPosition.y - rowIndex * prefabRectTransform.rect.height, prefabPosition.z
            );
            
            var inventoryUIRow = Instantiate(
                InventoryUIRowPrefab, rowPosition, Quaternion.identity, _inventoryUI.transform
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