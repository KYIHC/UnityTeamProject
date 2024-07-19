using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    public int slotNum;
    public Item item;
    public Image itemicon;


    public bool isShopMode;
    public bool isSell = false;
    public GameObject checkSell;


    public void UpdateSlotUI()
    {
        itemicon.sprite = item.itemImage;
        itemicon.gameObject.SetActive(true);
    }
    public void RemoveSlot()
    {
        item = null;
        itemicon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData) // 클릭했을때
    {
       
        if (item != null)
        {
            if (!isShopMode) // 사용모드
            {
                bool isUse = item.Use();
                if (isUse)
                { 
                    Inventory.instance.RemoveItem(slotNum);
                }
            }
            else // 상점모드
            {
                isSell = true; // 상점모드에서 클릭하면, isSell로 바꾸고 CheckSell을 활성화
                checkSell.SetActive(true);

            }
        }

    }

    public void SellItem()
    {
        if (isSell)
        {
            ItemDatabase.instance.Money += item.itemCost;
            Inventory.instance.RemoveItem(slotNum);
            isSell = false;
            checkSell.SetActive(isSell);
        }
    }

    private void OnDisable()
    {
        isSell = false;
        checkSell.SetActive(isSell);
    }
}
