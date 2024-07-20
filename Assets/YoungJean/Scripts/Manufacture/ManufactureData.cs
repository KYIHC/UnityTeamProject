using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManufactureData : MonoBehaviour
{
    public List<Item> stocks = new List<Item>();
    
    private void Start()
    {
        stocks.Add(ItemDatabase.instance.itemsDB[5]);    
        stocks.Add(ItemDatabase.instance.itemsDB[6]);
    
    }
}
