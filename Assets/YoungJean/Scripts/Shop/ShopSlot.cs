using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour
{
    public int slotnum;
    public Item item;
    public Image itemIcon;
    public bool soldOut;

    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }
    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (item != null)
        {
            if (ItemDatabase.instance.Money >= item.itemCost && !soldOut)
            {
                ItemDatabase.instance.Money -= item.itemCost;
                Inventory.instance.Additem(item);

            }
            else
            {

            }
        }
    }
}
