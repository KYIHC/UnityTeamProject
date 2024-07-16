using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
   public static InventoryManager instance;

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
   private int slotCount;

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
        slotCount = 4;
    }
}
