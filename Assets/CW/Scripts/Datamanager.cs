using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datamanager : MonoBehaviour
{
    PlayerJson playerJson;
    public List<PlayerData> playerDataList = new List<PlayerData>();
    PlayerData userData;
    public float playerDamage;
    public Character character;
    


    private void Start()
    {
        playerJson = new PlayerJson();
        playerJson.Load();
        playerDataList = playerJson.readFromJson??new List<PlayerData>();


        
    }

    

    public List<BaseBuff> onBuff = new List<BaseBuff>();

    public float BuffChange(string type,float origin)
    {
        if(onBuff.Count>0)
        {
            float temp = 0;
            for(int i=0;i<onBuff.Count;i++)
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

    /*public void ChooseBuff(string type)
    {
        switch (type)
        {
            case "Atk":
                character..attackDamage = BuffChange(type, );
                break;

        }
    }*/
}
