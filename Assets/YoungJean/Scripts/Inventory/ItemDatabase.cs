using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public int Money;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemsDB = new List<Item>();

    public GameObject fieldItemPrefab;
    public GameObject[] pos;

    private void Start()
    {
        Money = 1000;
        //���� ����
        GameObject go = Instantiate(fieldItemPrefab, pos[0].transform.position, Quaternion.identity);
        go.GetComponent<FieldItems>().SetItem(itemsDB[0]);

        //�� ����
         go = Instantiate(fieldItemPrefab, pos[1].transform.position, Quaternion.identity);
        go.GetComponent<FieldItems>().SetItem(itemsDB[1]);
        
        // ��Ÿ ������ ����
        for(int i = 2; i < 6; i++)
        {
            go = Instantiate(fieldItemPrefab, pos[i].transform.position, Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemsDB[Random.Range(2, 5)]);
        }
        /*for (int i = 0; i < 6; i++)
        {

         GameObject go =  Instantiate(fieldItemPrefab, pos[i].transform.position,Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemsDB[Random.Range(0, 3)]);
        }*/
    }
}
