using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralGood : MonoBehaviour
{
    GameObject player;
    public GameObject Shop;
    public bool isOpen;

    public ShopData shopData;
    public ShopSlot[] shopSlots;
    public Transform shopHolder;

    private void Start()
    {
        Shop.SetActive(false);
        player = GameObject.Find("Character");
        shopSlots = shopHolder.GetComponentsInChildren<ShopSlot>();
        for(int i = 0; i < shopSlots.Length; i++)
        {
            shopSlots[i].Init(this); 
            shopSlots[i].slotnum = i;
        }
    }
    private void Update()
    {

        if (Vector3.Distance(player.transform.position, transform.position) < 2 && Input.GetKeyDown(KeyCode.F))
        {
            isOpen = true;
            ActiveShop(isOpen);
            shopData = transform.GetComponent<ShopData>();
           
            for (int i = 0; i < shopData.stocks.Count; i++)
            {
                shopSlots[i].item = shopData.stocks[i];
                shopSlots[i].UpdateSlotUI();
            }
        }
        else if (Vector3.Distance(player.transform.position, transform.position) < 10)
        {
            //라인랜더러 해제
            QuestHelper.instance.lineRenderer.positionCount = 0;
            QuestHelper.instance.isDraw = false;
        }
        else
        {
            // do something else
        }
    }

    public void OnShopExit()
    {
        isOpen = false;
        ActiveShop(isOpen);
        shopData = null;
        for(int i = 0; i < shopSlots.Length; i++)
        {
            shopSlots[i].RemoveSlot();
        }
        /*Shop.SetActive(false);
        InventoryUI.instance.activeInventory = false;

        InventoryUI.instance.inventoryPanel.SetActive(InventoryUI.instance.activeInventory);*/

    }
    public void ActiveShop(bool isOpen)
    {
        Shop.SetActive(isOpen);
        InventoryUI.instance.activeInventory = isOpen;
        InventoryUI.instance.inventoryPanel.SetActive(InventoryUI.instance.activeInventory);
        for (int i = 0; i < InventoryUI.instance.slots.Length; i++)
        {
            InventoryUI.instance.slots[i].isShopMode = isOpen;
        }
    }

    public void SellButton()
    {
        for (int i = InventoryUI.instance.slots.Length; i > 0; i--)
        {
            InventoryUI.instance.slots[i - 1].SellItem();
        }
    }

    public void Buy(int index)
    {
        shopData.soldOuts[index] = true;

    }


}
