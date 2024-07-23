using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;



public class InventoryUI : MonoBehaviour
{
    Inventory inven;
    public GameObject inventoryPanel;
    public bool activeInventory = false;
    public static InventoryUI instance;
    public Slot[] slots;
    public Transform slotHolder;
    public Text CurrentMoney;

    public GameObject upgradePanel;
    public bool activeUpgradePanel;


    public TextMeshProUGUI upgradeText;
    public Image UpgradeImage;
    public TextMeshProUGUI UpgradeDescription;
    public Item upgradedItem;

    



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
        upgradePanel.SetActive(false);


    }


    private void SlotChange(int val)
    {
        for (int i = 0; i < slots.Length; i++)
        {

            slots[i].slotNum = i;
            if (i < inven.SlotCount)
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
        if (Input.GetKeyDown(KeyCode.I))
        {

            activeInventory = !activeInventory;

            inventoryPanel.SetActive(activeInventory);

        }
        CurrentMoney.text = "Money : " + ItemDatabase.instance.Money.ToString();

        if (!activeInventory)
        {
            upgradePanel.SetActive(false);
            activeUpgradePanel = false;
        }
    }

    public void addSlot()
    {
        inven.SlotCount++;
        ItemDatabase.instance.Money -= 50;
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

    public void ShowUpgradePanel()
    {
        activeUpgradePanel = !activeUpgradePanel;
        upgradePanel.SetActive(activeUpgradePanel);
        UpgradeImage.gameObject.SetActive(false);

        upgradeText.text = "��ȭ�ϰ� ���� �������� �����ϼ���.";
        UpgradeDescription.text = "";




    }

    public void Upgrade()
    {
        bool luneStone = false;
        bool inchanter = false;

        for (int i = 0; i < inven.items.Count; i++)
        {
            if (inven.items[i].itemName == ItemDatabase.instance.itemsDB[5].itemName)
            {
                luneStone = true;
                break;
            }
        }
        for (int i = 0; i < inven.items.Count; i++)
        {
            if (inven.items[i].itemName == ItemDatabase.instance.itemsDB[7].itemName)
            {
                inchanter = true;
                break;
            }
        }

        if (luneStone && inchanter) // ��ȭ�� ������ ���
        {
            for (int i = 0; i < inven.items.Count; i++)
            {
                if (inven.items[i].itemName == ItemDatabase.instance.itemsDB[5].itemName)
                {
                    inven.RemoveItem(i);
                    break;
                }
            }
            for (int i = 0; i < inven.items.Count; i++)
            {
                if (inven.items[i].itemName == ItemDatabase.instance.itemsDB[7].itemName)
                {
                    inven.RemoveItem(i);
                    break;
                }
            }
            ItemDatabase.instance.Money -= upgradedItem.itemCost;
            if (UnityEngine.Random.Range(0, 10) < 10 - upgradedItem.inchantLevel)
            {
                
                upgradedItem.inchantLevel++;

                if (upgradedItem.atk > 0)
                {
                    upgradedItem.atk += 5;
                }
                else if (upgradedItem.def > 0)
                {
                    upgradedItem.def += 5;
                }

                Debug.Log("��ȭ����");
                
                if (upgradedItem.atk > 0)
                {
                    
                    UpgradeDescription.text =
                        "���� ��ȭ���� : " + upgradedItem.inchantLevel +
                        "\n���ݷ� : " + upgradedItem.atk +
                        "\n��ȭ��� : " + upgradedItem.itemCost +
                        "\n��ȭ��� : " + ItemDatabase.instance.itemsDB[5].itemName + " , " + ItemDatabase.instance.itemsDB[7].itemName +
                        "\n ��ȭ Ȯ��" + (10 - upgradedItem.inchantLevel) * 10 + "%";
                }
                else if (upgradedItem.def > 0)
                {
                    UpgradeDescription.text =
                        "���� ��ȭ���� : " + upgradedItem.inchantLevel +
                        "\n���� : " + upgradedItem.def +
                        "\n��ȭ��� : " + upgradedItem.itemCost +
                        "\n��ȭ��� : " + ItemDatabase.instance.itemsDB[5].itemName + " , " + ItemDatabase.instance.itemsDB[7].itemName +
                        "\n ��ȭ Ȯ��" + (10 - upgradedItem.inchantLevel) * 10 + "%";

                }
                else
                {
                    Debug.Log("��ȭ����");
                }
            }

        }
        else
        {
            Debug.Log("��ȭ��ᰡ �����մϴ�.");
        }

    }
}
