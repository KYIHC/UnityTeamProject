using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;
    public GameObject inventoryPanel;
    public bool activeInventory = false;
    public static InventoryUI instance;
    public Slot[] slots;
    public Transform slotHolder;
    public Text CurrentMoney;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

    }

    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        RedrawSlotUI();
        inventoryPanel.SetActive(activeInventory);
        
        
    }
    

    private void SlotChange(int val)
    {
        for(int i = 0; i < slots.Length; i++)
        {

            slots[i].slotNum = i;
            if(i < inven.SlotCount)
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
        CurrentMoney.text = "Money : " + ItemDatabase.instance.Money.ToString();
       
    }

    public void addSlot()
    {
        inven.SlotCount++;
        ItemDatabase.instance.Money -= 100;
    }

    void RedrawSlotUI()
    {
        for (int i = 0; i < slots.Length; i++)
            slots[i].RemoveSlot();
        for (int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }           


    }
    
}
