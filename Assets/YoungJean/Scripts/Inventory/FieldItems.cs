using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        item.itemCost = _item.itemCost;
        item.description = _item.description;
        item.inchantLevel = _item.inchantLevel;
        item.atk = _item.atk;
        item.def = _item.def;

        image.sprite = _item.itemImage;
        item.efts = _item.efts;
    }

    public Item GetItem()
            {
        return item;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
