using System;
using UnityEngine;

namespace Game
{
    public class Item
    {
        public readonly string Name;
        public readonly Sprite Sprite;
        public int Quantity = 1;

        public Item(string name, Sprite sprite)
        {
            Name = name;
            Sprite = sprite;
        }
    }
}