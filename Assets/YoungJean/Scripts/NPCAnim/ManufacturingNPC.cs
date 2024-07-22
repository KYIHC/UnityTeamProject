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
            Debug.Log("���õ� �������� �����ϴ�.");
            return;
        }
        else
        {
            /* foreach (Item Item in ItemDatabase.instance.itemsDB)
             {
                 if (Item.itemName == PlayerPrefs.GetString("Select"))
                 {
                     //������ �߰�
                     Inventory.instance.Additem(Item);                 


                 }

             }
             Debug.Log("���� Ŭ��");*/
            CheckMaterial();
        }
    }

    public void CheckMaterial()
    {

        for (int i = 0; i < ItemDatabase.instance.itemsDB.Count; i++)
        {
            // ���õ� �����۰� ������ �̸��� ��ġ�ϴ��� Ȯ��
            if (ItemDatabase.instance.itemsDB[i].itemName == PlayerPrefs.GetString("Select"))
            {
                bool allMaterialsPresent = true;

                // ��� �ʿ��� ������ �κ��丮�� �ִ��� Ȯ��
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

                // ��� ��ᰡ �κ��丮�� ���� ���, �κ��丮���� ������ �����ϰ� ������ �߰�
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

                    // ���۵� �������� �κ��丮�� �߰�
                    Inventory.instance.Additem(ItemDatabase.instance.itemsDB[i]);
                }
                else
                {
                    Debug.Log("�ʿ��� ��ᰡ �����մϴ�.");
                }
            }
        }
    }

}
