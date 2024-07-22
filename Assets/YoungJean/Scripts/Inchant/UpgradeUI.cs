using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public bool isOpen;

    public GameObject UpgradeUIPanel;

    public GameObject Origin;
    public Item OriginItem;
    public ManufacturingSlot[] materials;
    

    private void Awake()
    {
        UpgradeUIPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
            if(isOpen)
            {
                UpgradeUIPanel.SetActive(isOpen);
                InventoryUI.instance.activeInventory = isOpen;
                InventoryUI.instance.inventoryPanel.SetActive(isOpen);

                
            }
        }

        if(PlayerPrefs.HasKey("Upgrade"))
        {
            OriginItem = Inventory.instance.items[PlayerPrefs.GetInt("Upgrade")];
            Origin.GetComponent<ManufacturingSlot>().item = OriginItem;
        }
        
       

    }
    public void OnUpgradeExit()
    {
        isOpen = false;
        UpgradeUIPanel.SetActive(isOpen);
        InventoryUI.instance.activeInventory = isOpen;
        InventoryUI.instance.inventoryPanel.SetActive(isOpen);
        
    }






}
