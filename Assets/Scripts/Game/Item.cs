using System;
using UnityEngine;

public class Item
{
    public readonly string Name;
    public readonly Sprite Sprite;

    public Item(String name, Sprite sprite)
    {
        Name = name;
        Sprite = sprite;
    }
}