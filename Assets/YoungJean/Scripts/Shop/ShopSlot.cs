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
    GeneralGood ShopUI;

    public void Init(GeneralGood SUI)
    {
        ShopUI = SUI; 
    }

    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
        if (soldOut)
        {
           itemIcon.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else itemIcon.color = new Color(1, 1, 1);
    }
    public void RemoveSlot()
    {
        item = null;
        soldOut = false;
        itemIcon.gameObject.SetActive(false);
    }

    public void onBuyButton()
    {
        if (item != null)
        {
            if (ItemDatabase.instance.Money >= item.itemCost && !soldOut && Inventory.instance.items.Count < Inventory.instance.SlotCount)
            {
                ItemDatabase.instance.Money -= item.itemCost;
                Inventory.instance.Additem(item);
                if (item.itemType != ItemType.Consumables ) 
                    soldOut = true;
                ShopUI.Buy(slotnum);
                UpdateSlotUI();
            }
            else
            {

            }
        }

        /* public void OnPointerUp(PointerEventData eventData) 
         {
             Debug.Log("구매 클릭");
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
         }*/
    }
}
