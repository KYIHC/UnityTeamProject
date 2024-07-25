using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Character character;

    public short DungeonPhase = 0;

    public List<Item> items = new List<Item>();
    public int SlotCount=4;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("���� �Ŵ����� �ΰ��Դϴ�.");
            Destroy(gameObject);
        }
    }

    

}
