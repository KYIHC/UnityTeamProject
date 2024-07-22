using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum ItemType
{
    Equipment,
    Consumables,
    Etc,    
    Manufacture,
}

[Serializable]
public class Item 
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    public int inchantLevel=1;
    public List<ItemEffect> efts;
    public int itemCost;
    public string description;
    public int atk;
    public int def;
    
    public List<string> materials;
    public List<int> materialCount;

    public bool Use()
    {
        bool isUsed = false;
        foreach(ItemEffect eft in efts)
        {
            isUsed = eft.ExecuteEffect();            
        }
        return isUsed;
        
    }

}
