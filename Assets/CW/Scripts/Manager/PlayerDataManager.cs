using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager instance;

    PlayerJson playerJson;
    public List<PlayerData> playerDataList = new List<PlayerData>();
    public bool isFirst= true;


    public PlayerData playerData;

    Character character;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        playerJson = new PlayerJson();
        playerJson.Load();
        playerDataList = playerJson.readFromJson ?? new List<PlayerData>();
        character = FindObjectOfType<Character>();
        playerData.name = "������� ����";
        
    }

    private void Start()
    {
        playerDataList[0].attackDamage = character.damage;
        playerDataList[0].armorDef = character.def;
    }



    public List<BaseBuff> onBuff = new List<BaseBuff>();

    public float BuffChange(string type, float origin)
    {
        if (onBuff.Count > 0)
        {
            float temp = 0;
            for (int i = 0; i < onBuff.Count; i++)
            {
                if (onBuff[i].type.Equals(type))
                    temp += origin * onBuff[i].percentage;
            }
            return origin + temp;
        }
        else
        {
            return origin;
        }
    }

    public void ChooseBuff(string type)
    {

        switch (type)
        {
            case "Atk":
                playerData.attackDamage = BuffChange(type, playerDataList[0].attackDamage);

                break;
            

                





        }
    }

}
