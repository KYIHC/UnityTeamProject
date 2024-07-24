using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;


public class PlayerJson : MonoBehaviour
{
    public List<PlayerData> playerDatas;
    public List<PlayerData> readFromJson = new List<PlayerData>();


    public void Save()
    {
        if (playerDatas == null)
        {
            Debug.LogError("playerDatas ����Ʈ�� NULL�Դϴ�");
            return;
        }

        if(playerDatas.Count==0)
        {
            Debug.LogWarning("playerDatas ����Ʈ�� ��� �ֽ��ϴ�.");
            return;
        }
        foreach(PlayerData data in playerDatas)
        {
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {
        readFromJson.Clear();

        string[] names = { "������� ����" };

        foreach(string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            if(File.Exists(path))
            {
                string json = File.ReadAllText(path);
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(json);
                readFromJson.Add(data);
            }
        }
    }
}


[Serializable]
public class PlayerData
{
    public string name;
    public float attackDamage = 25;
    public int gold;
    public float CurrentHp=200;
    public float maxHp = 200;
    public float armorDef;
}






