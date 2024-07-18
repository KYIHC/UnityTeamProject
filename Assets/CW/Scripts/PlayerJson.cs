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

        string[] names = { "" };

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

public class PlayerData
{
    public string name;
    public int attackDamage = 25;
    public int gold;
    public int CurrentHp;
    public int maxHp = 200;
}




