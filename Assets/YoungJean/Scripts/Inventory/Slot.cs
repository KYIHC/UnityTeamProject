using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public Image itemicon;

   
    
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
}
