using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InchantSlot : MonoBehaviour
{
    public int slotnum;
    public Item item;
    public Image itemIcon;

    UpgradeUI InchantUI;

    public void Init(UpgradeUI UUI)
    {
        InchantUI = UUI;
    }
    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }
    
}
