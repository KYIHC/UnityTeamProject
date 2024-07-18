using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MonsterDataToJson : MonoBehaviour
{
    public List<MonsterData> monsterDatas;
    public Dictionary<string, MonsterData> readFromJson = new Dictionary<string, MonsterData>();

    public void Save()
    {
        foreach (MonsterData data in monsterDatas)
        {
            string path = $"{Application.streamingAssetsPath}/{data.name}_Data.json";
            string json = JsonUtility.ToJson(data); 
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {
        readFromJson.Clear();

        string[] names = { "소드맨", "매지션", "리치왕", "리치왕2" };

        foreach (string name in names)
        {
            string path = $"{Application.streamingAssetsPath}/{name}_Data.json";

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                MonsterData data = JsonConvert.DeserializeObject<MonsterData>(json);
                readFromJson.Add(name, data);
            }
        }
        Debug.Log(readFromJson["소드맨"]);
    }
}


[Serializable]
public class MonsterData
{
    public string name;
    public float maxHP;
    public float currentHP;
    public float damage;
    public List<SkillData> skills;
}
[Serializable]
public class SkillData
{
    public int id;
    public float damage;
    public float coolTime;
}
