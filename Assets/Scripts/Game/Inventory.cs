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

        private bool HasItem(String name)
        {
            if (!Items.ContainsKey(name))
            {
                return false;
            }

            return Items[name].Quantity > 0;
        }

        private void UseItem(String name)
        {
            if (!HasItem(name))
            {
                throw new Exception("The player doesn't have any '" + name + "' item.");
            }

            Items[name].Quantity -= 1;
            if (Items[name].Quantity <= 0)
            {
                Items.Remove(name);
            }

            GameManager.Instance.InventoryUIManager.HandleInventoryUpdate();
        }
    }
}