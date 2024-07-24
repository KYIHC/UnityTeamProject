using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Character character;
    public short DungeonPhase;

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

        DungeonPhase = 1;
    }

}
