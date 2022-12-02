using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Inventory : MonoBehaviour
    {
        private Dictionary<string, Item> items;

        public void PickUp(Item item)
        {
            AddItemToInventory(item);
            GameManager.Instance.InventoryUIManager.HandleInventoryUpdate();
        }

        private void AddItemToInventory(Item item)
        {
            if (items.ContainsKey(item.Name))
            {
                items[item.Name].Quantity += item.Quantity;
            }
            else
            {
                items.Add(item.Name, item);
            }
        }
    }
}