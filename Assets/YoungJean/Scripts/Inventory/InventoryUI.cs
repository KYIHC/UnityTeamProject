using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    InventoryManager inventoryManager;
    public GameObject inventoryPanel;
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHolder; 

    private void Start()
    {
        inventoryManager = InventoryManager.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inventoryManager.onSlotCountChange += SlotChange;
        inventoryPanel.SetActive(activeInventory);   
    }

    private void SlotChange(int val)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventoryManager.SlotCount)
            {
                slots[i].GetComponent<Button>().interactable = true;    
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    public void addSlot()
    {
        inventoryManager.SlotCount++;
    }
}
