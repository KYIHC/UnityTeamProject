using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemsDB = new List<Item>();

    public GameObject fieldItemPrefab;
    public GameObject[] pos;

    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {

         GameObject go =  Instantiate(fieldItemPrefab, pos[i].transform.position,Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemsDB[Random.Range(0, 3)]);
        }
    }
}
