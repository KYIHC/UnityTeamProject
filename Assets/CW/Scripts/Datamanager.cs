using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datamanager : MonoBehaviour
{
    public static Datamanager instance;
    PlayerJson playerJson;
    public List<PlayerData> playerDataList = new List<PlayerData>();
    PlayerData userData;
    public float playerDamage;
    public PlayerStats playerStat;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }
        instance = this;
    }

    private void Start()
    {
        playerJson = new PlayerJson();
        playerJson.Load();
        playerDataList = playerJson.readFromJson ?? new List<PlayerData>();



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
                playerStat.Atk = BuffChange(type, playerDataList[0].attackDamage);
                break;
            case "Def":
                playerStat.Def = BuffChange(type, playerDataList[0].armorDef);
                break;


        }
    }
}
