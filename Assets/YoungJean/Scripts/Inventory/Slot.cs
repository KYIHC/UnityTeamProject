using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    public int slotNum;
    public Item item;
    public Image itemicon;


    public bool isShopMode;
    public bool isSell = false;
    public GameObject checkSell;
    public Outline outline;

    


    public void UpdateSlotUI()
    {
        itemicon.sprite = item.itemImage;
        itemicon.gameObject.SetActive(true);
    }
    public void RemoveSlot()
    {
        item = null;
        itemicon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData) // Ŭ��������
    {

        if (item != null)
        {
            if (!isShopMode) // �����
            {
                bool isUse = item.Use();

                if (item.itemType == ItemType.Equipment)
                {

                    if (InventoryUI.instance.upgradePanel.activeSelf == true)
                    {
                        InventoryUI.instance.upgradeText.text = item.itemName + "�� ��ȭ�Ͻðڽ��ϱ�?";
                        InventoryUI.instance.UpgradeImage.sprite = item.itemImage;
                        InventoryUI.instance.UpgradeImage.gameObject.SetActive(true);

                        if (item.atk > 0)
                        {
                            InventoryUI.instance.UpgradeDescription.text
                            = "���� ��ȭ���� : " + item.inchantLevel +
                              "\n���ݷ� : " + item.atk +
                              "\n��ȭ��� : " + item.itemCost +
                              "\n��ȭ��� : " + ItemDatabase.instance.itemsDB[5].itemName + " , " + ItemDatabase.instance.itemsDB[7].itemName +
                             "\n ��ȭ Ȯ��" + (10 - item.inchantLevel) * 10 + "%";
                        }
                        else if (item.def > 0)
                        {
                            InventoryUI.instance.UpgradeDescription.text
                            = "���� ��ȭ���� : " + item.inchantLevel +
                              "\n���� : " + item.def +
                              "\n��ȭ��� : " + item.itemCost +
                              "\n��ȭ��� : " + ItemDatabase.instance.itemsDB[5].itemName + " , " + ItemDatabase.instance.itemsDB[7].itemName +
                              "\n ��ȭ Ȯ��" + (10 - item.inchantLevel) * 10 + "%";
                        }

                        InventoryUI.instance.upgradedItem = item;

                    }



                }
                if (isUse)
                {
                    Inventory.instance.RemoveItem(slotNum);
                }
            }
            else // �������
            {
                isSell = true; // ������忡�� Ŭ���ϸ�, isSell�� �ٲٰ� CheckSell�� Ȱ��ȭ
                checkSell.SetActive(true);

            }
        }

    }

    public void SellItem()
    {
        if (isSell)
        {
            ItemDatabase.instance.Money += item.itemCost;
            Inventory.instance.RemoveItem(slotNum);
            isSell = false;
            checkSell.SetActive(isSell);
        }
    }

    private void OnDisable()
    {
        isSell = false;
        checkSell.SetActive(isSell);
    }

    private void Update()
    {
        if (item != null)
        {
            if (item.inchantLevel == 1)
            {
                outline.enabled = false;
            }
            else if (item.inchantLevel < 3)
            {
                outline.enabled = true;
                outline.effectColor = Color.green;
            }
            else if (item.inchantLevel < 4)
            {
                outline.enabled = true;
                outline.effectColor = Color.blue;
            }
            else if (item.inchantLevel < 5)
            {
                outline.enabled = true;
                outline.effectColor = Color.red;
            }
            else if (item.inchantLevel < 6)
            {
                outline.enabled = true;
                outline.effectColor = Color.magenta;
            }
            else if (item.inchantLevel < 7)
            {
                outline.enabled = true;
                outline.effectColor = Color.cyan;
            }
            else if (item.inchantLevel < 8)
            {
                outline.enabled = true;
                outline.effectColor = Color.white;
            }
            else if (item.inchantLevel < 9)
            {
                outline.enabled = true;
                outline.effectColor = Color.black;
            }
            else if (item.inchantLevel == 10)
            {
                outline.enabled = true;
                outline.effectColor = Color.yellow;
            }
        }
    }
}
