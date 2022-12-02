using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Inventory : MonoBehaviour
    {
        public List<Item> items = new();

        public void PickUp(Item item)
        {
            items.Add(item);
            GameManager.Instance.InventoryUIManager.HandleInventoryUpdate();
        }
    }
}