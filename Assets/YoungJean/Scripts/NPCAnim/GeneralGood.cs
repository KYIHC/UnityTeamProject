using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralGood : MonoBehaviour
{
    GameObject player;
    public GameObject Shop;

    private void Start()
    {
        Shop.SetActive(false);
        player = GameObject.Find("Character");
    }
    private void Update()
    {

        if (Vector3.Distance(player.transform.position, transform.position) < 2 && Input.GetKeyDown(KeyCode.F))
        {
            Shop.SetActive(true);
            InventoryUI.instance.activeInventory = true;
            InventoryUI.instance.inventoryPanel.SetActive(InventoryUI.instance.activeInventory);
            
        }
        else if (Vector3.Distance(player.transform.position, transform.position) < 10)
        {
            //���η����� ����
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
        Shop.SetActive(false);
        InventoryUI.instance.activeInventory = false;

        InventoryUI.instance.inventoryPanel.SetActive(InventoryUI.instance.activeInventory);

    }
}
