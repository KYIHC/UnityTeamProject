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

        upgradeText.text = "강화하고 싶은 아이템을 선택하세요.";
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

        if (luneStone && inchanter) // 강화가 가능한 경우
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

                Debug.Log("강화성공");
                
                if (upgradedItem.atk > 0)
                {
                    
                    UpgradeDescription.text =
                        "현재 강화레벨 : " + upgradedItem.inchantLevel +
                        "\n공격력 : " + upgradedItem.atk +
                        "\n강화비용 : " + upgradedItem.itemCost +
                        "\n강화재료 : " + ItemDatabase.instance.itemsDB[5].itemName + " , " + ItemDatabase.instance.itemsDB[7].itemName +
                        "\n 강화 확률" + (10 - upgradedItem.inchantLevel) * 10 + "%";
                }
                else if (upgradedItem.def > 0)
                {
                    UpgradeDescription.text =
                        "현재 강화레벨 : " + upgradedItem.inchantLevel +
                        "\n방어력 : " + upgradedItem.def +
                        "\n강화비용 : " + upgradedItem.itemCost +
                        "\n강화재료 : " + ItemDatabase.instance.itemsDB[5].itemName + " , " + ItemDatabase.instance.itemsDB[7].itemName +
                        "\n 강화 확률" + (10 - upgradedItem.inchantLevel) * 10 + "%";

                }
                else
                {
                    Debug.Log("강화실패");
                }
            }

        }
        else
        {
            Debug.Log("강화재료가 부족합니다.");
        }

    }
}
