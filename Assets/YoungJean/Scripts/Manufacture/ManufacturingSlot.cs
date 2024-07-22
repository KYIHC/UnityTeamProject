using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManufacturingSlot : MonoBehaviour
{
    public int slotnum;
    public Item item;
    public Image itemIcon;
    
    ManufacturingNPC ManuFactureUI;

    public void Init(ManufacturingNPC MFUI)
    {
        ManuFactureUI = MFUI;
    }
    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }
    public void Select()
    {
        
        PlayerPrefs.SetString("Select", item.itemName);

    }
  
    
}
