using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    public List<Item> stocks = new List<Item>();
    public bool[] soldOuts;
    private void Start()
    {
        stocks.Add(ItemDatabase.instance.itemsDB[0]);
        stocks.Add(ItemDatabase.instance.itemsDB[1]);
        stocks.Add(ItemDatabase.instance.itemsDB[2]);
      
        soldOuts = new bool[stocks.Count];
        for(int i = 0; i < soldOuts.Length; i++)
        {
            soldOuts[i] = false;
        }
    }

}
