using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDataManager : MonoBehaviour
{
    public static MonsterDataManager instance;
    
    MonsterDataToJson monsterDataToJson;
    
    public Dictionary<string, MonsterData> monsterDataDic = new Dictionary<string, MonsterData>();
    public MonsterData swordManData;
    public MonsterData magicData;
    public MonsterData bossPhaseOne;
    public MonsterData bossPhaseTwo;
    public float swordManDamage;
    public float bossAttackDamage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        monsterDataToJson = new MonsterDataToJson();
        monsterDataToJson.Load();
        monsterDataDic = monsterDataToJson.readFromJson;
        swordManData = monsterDataDic["�ҵ��"];
        magicData = monsterDataDic["������"];
        bossPhaseOne = monsterDataDic["��ġ��"];
        bossPhaseTwo = monsterDataDic["��ġ��2"];
    }

}
