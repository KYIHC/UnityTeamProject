using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Text;

public class PlayerData
{
    public string name;
    public int attackDamage=25;
    public int gold;
    public int CurrentHp;
    public int maxHp=200;
}



public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    PlayerData playerData = new PlayerData();

    string path;
    string filename = "save";

    private void Awake()
    {
        #region ΩÃ±€≈Ê
        if (instance==null)
        {
            instance = this;

        }

        else if(instance!=this)
        {
            Destroy(instance.gameObject);

        }

        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = $"{Application.streamingAssetsPath}/{playerData.name}_Data.json";
    }

    private void Start()
    {
        
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(playerData);
        File.WriteAllText(path + filename, data);
    }

    public void LoadData()
    {
        string data=File.ReadAllText(path + filename);
        playerData=JsonUtility.FromJson<PlayerData>(data);
    }
}

    /*
    public Text text;

    public List<PlayerStat> playerStats;
    public List<PlayerStat> readFromJson = new List<PlayerStat>();


    private void Start()
    {
        *//*StringBuilder sb = new StringBuilder();

        sb.Append("Data Path : ");
        sb.AppendLine(Application.dataPath);
        sb.Append("Pers data path : ");
        sb.AppendLine(Application.persistentDataPath);
        sb.Append("Str data path : ");
        sb.AppendLine(Application.streamingAssetsPath);

        text.text = sb.ToString();*//*
    }

    public void Save()
    {
        foreach(PlayerStat stat in playerStats)
        {
            string path = $"{Application.streamingAssetsPath}/{"Player"}_Data.json";
            string json = JsonConvert.SerializeObject(stat);
            File.WriteAllText(path, json);
        }
    }

    public void Load()
    {
        readFromJson.Clear
    }
}







[System.Serializable]
public class PlayerStat
{
    public int hp;
    public int attackDamage;
    public bool skill;
    

}*/
