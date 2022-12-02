using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Inventory : MonoBehaviour
    {
        public readonly Dictionary<string, Item> Items = new();

        public void PickUp(Item item)
        {
            AddItemToInventory(item);
            GameManager.Instance.InventoryUIManager.HandleInventoryUpdate();
        }

        private void AddItemToInventory(Item item)
        {
            if (Items.ContainsKey(item.Name))
            {
                Items[item.Name].Quantity += item.Quantity;
            }
            else
            {
                Items.Add(item.Name, item);
            }
        }
    }
}