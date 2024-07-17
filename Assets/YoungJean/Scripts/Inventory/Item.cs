using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum ItemType
{
    Equipment,
    Consumables,
    Etc
}

[Serializable]
public class Item 
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;

    public bool Use()
    {
        return false;
    }

}
