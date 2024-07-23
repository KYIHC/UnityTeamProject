using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

    }

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;
    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;
    private int slotCount;
    public List<Item> items = new List<Item>();
    public int SlotCount
    {
        get => slotCount;
        set
        {
            slotCount = value;
            onSlotCountChange?.Invoke(slotCount);
        }
    }
    private void Start()
    {
        SlotCount = 4;
    }
    public bool Additem(Item _item)
    {
        if (items.Count < SlotCount)
        {
            items.Add(_item);

            onChangeItem?.Invoke();
            return true;

        }
        return false;
    }
    // �ֺ��� �ݶ��̴��� Ž��
    public void Update()
    {
        // 1�Ÿ��� �ִ� �ݶ��̴��� �̸��� ������
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1);
        foreach (var item in colliders)
        {
            if (item.CompareTag("Item"))
            {
                Item _item = item.GetComponent<FieldItems>().item;
                if (Additem(_item))
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }

    public void RemoveItem(int index)
    {
        
        items.RemoveAt(index);
        onChangeItem?.Invoke();
    }
}
