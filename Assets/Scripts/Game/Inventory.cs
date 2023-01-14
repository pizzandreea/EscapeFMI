using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class Inventory : MonoBehaviour
    {
        public bool shouldUpdateUI;
        private readonly Dictionary<string, Item> _items = new();

        public Dictionary<string, Item> GetItems()
        {
            return _items;
        }
        
        public void PickUp(Item item)
        {
            AddItemToInventory(item);
            shouldUpdateUI = true;
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

        private bool HasItem(String name)
        {
            if (!_items.ContainsKey(name))
            {
                return false;
            }

            return _items[name].Quantity > 0;
        }

        private void UseItem(String name)
        {
            if (!HasItem(name))
            {
                throw new Exception("The player doesn't have any '" + name + "' item.");
            }

            _items[name].Quantity -= 1;
            if (_items[name].Quantity <= 0)
            {
                _items.Remove(name);
            }

            shouldUpdateUI = true;
        }

        public void Clear()
        {
            Debug.Log("clearrr");
            _items.Clear();
            shouldUpdateUI = true;
        }
    }
}