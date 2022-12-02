using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Inventory : MonoBehaviour
    {
        private readonly Dictionary<string, Item> _items = new();

        public void PickUp(Item item)
        {
            AddItemToInventory(item);
            GameManager.Instance.InventoryUIManager.HandleInventoryUpdate();
        }

        private void AddItemToInventory(Item item)
        {
            if (_items.ContainsKey(item.Name))
            {
                _items[item.Name].Quantity += item.Quantity;
            }
            else
            {
                _items.Add(item.Name, item);
            }
        }
    }
}