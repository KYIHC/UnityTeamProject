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
        for(int i = 0; i < manufactureData.stocks.Count; i++)
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

    
}
