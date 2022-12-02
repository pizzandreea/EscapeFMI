using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Inventory : MonoBehaviour
    {
        public List<Item> items = new();

        public void PickUp(Item item)
        {
            Debug.Log("Picked up " + item.Name);
            items.Add(item);
        }
    }
}