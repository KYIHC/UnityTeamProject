using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManufacturingNPC : MonoBehaviour
{
    private Animator anim;
    private GameObject player;

    public GameObject Manufacture;
    private DialogueManager theDM;
    public bool isOpen;


    public ManufactureData manufactureData;
    public ManufacturingSlot[] manufactureSlots;
    public Transform manufactureHolder;


    public enum NPCState
    {
        Idle,
        Talking,
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Character");
        theDM = FindObjectOfType<DialogueManager>();
        Setstate(NPCState.Idle);

    }

    public void Start()
    {
        Manufacture.SetActive(false);
        manufactureSlots = manufactureHolder.GetComponentsInChildren<ManufacturingSlot>();
        for (int i = 0; i < manufactureSlots.Length; i++)
        {
            manufactureSlots[i].Init(this);
            manufactureSlots[i].slotnum = i;
        }

    }
    public void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 4 && Input.GetKeyDown(KeyCode.F))
        {
            Setstate(NPCState.Talking);

        }
        else if (distance < 10) Setstate(NPCState.Idle);


    }

    public void Setstate(NPCState nPCState)
    {
        switch (nPCState)
        {
            case NPCState.Idle:

                anim.SetBool("isTalk", false);
                break;
            case NPCState.Talking:

                anim.SetBool("isTalk", true);
                theDM.ShowDialogue(transform.GetComponent<InteractionEvent>().GetDialogue());
                isOpen = true;
                StartCoroutine(ShowManufactor(isOpen));

                manufactureData = transform.GetComponent<ManufactureData>();
                for (int i = 0; i < manufactureData.stocks.Count; i++)
                {
                    manufactureSlots[i].item = manufactureData.stocks[i];
                    manufactureSlots[i].UpdateSlotUI();
                }
                break;
        }
    }

    IEnumerator ShowManufactor(bool isOpen)
    {
        yield return new WaitUntil(() => !theDM.isDialogue);
        Manufacture.SetActive(isOpen);
        InventoryUI.instance.activeInventory = isOpen;
        InventoryUI.instance.inventoryPanel.SetActive(InventoryUI.instance.activeInventory);
        for (int i = 0; i < manufactureData.stocks.Count; i++)
        {
            manufactureSlots[i].item = manufactureData.stocks[i];
            manufactureSlots[i].UpdateSlotUI();
        }




    }

    public void OnManufactureExit()
    {
        isOpen = false;
        Manufacture.SetActive(isOpen);
        manufactureData = null;
    }

    public void StartManufacture()
    {
        if (PlayerPrefs.GetString("Select") == null)
        {
            Debug.Log("선택된 아이템이 없습니다.");
            return;
        }
        else
        {
            /* foreach (Item Item in ItemDatabase.instance.itemsDB)
             {
                 if (Item.itemName == PlayerPrefs.GetString("Select"))
                 {
                     //아이템 추가
                     Inventory.instance.Additem(Item);                 


                 }

             }
             Debug.Log("제조 클릭");*/
            CheckMaterial();
        }
    }

    public void CheckMaterial()
    {

        for (int i = 0; i < ItemDatabase.instance.itemsDB.Count; i++)
        {
            // 선택된 아이템과 아이템 이름이 일치하는지 확인
            if (ItemDatabase.instance.itemsDB[i].itemName == PlayerPrefs.GetString("Select"))
            {
                bool allMaterialsPresent = true;

                // 모든 필요한 재료들이 인벤토리에 있는지 확인
                foreach (string material in ItemDatabase.instance.itemsDB[i].materials)
                {
                    bool materialFound = false;

                    for (int j = 0; j < Inventory.instance.items.Count; j++)
                    {
                        if (Inventory.instance.items[j].itemName == material)
                        {
                            materialFound = true;
                            break;
                        }
                    }

                    if (!materialFound)
                    {
                        allMaterialsPresent = false;
                        break;
                    }
                }

                // 모든 재료가 인벤토리에 있을 경우, 인벤토리에서 재료들을 제거하고 아이템 추가
                if (allMaterialsPresent)
                {
                    foreach (string material in ItemDatabase.instance.itemsDB[i].materials)
                    {
                        for (int j = 0; j < Inventory.instance.items.Count; j++)
                        {
                            if (Inventory.instance.items[j].itemName == material)
                            {
                                Inventory.instance.RemoveItem(j);
                                break;
                            }
                        }
                    }

                    // 제작된 아이템을 인벤토리에 추가
                    Inventory.instance.Additem(ItemDatabase.instance.itemsDB[i]);
                }
                else
                {
                    Debug.Log("필요한 재료가 부족합니다.");
                }
            }
        }
    }

}
