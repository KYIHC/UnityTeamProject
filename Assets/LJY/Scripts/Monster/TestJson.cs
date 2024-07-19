using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJson : MonoBehaviour
{
    MonsterDataToJson monsterDataToJson;
    
    public Dictionary<string, MonsterData> monsterDataDic = new Dictionary<string, MonsterData>();
    public List<SkillData> bossDatas = new List<SkillData>();
    public List<SkillData> bossTwoDatas = new List<SkillData>();
    MonsterData swordManData;
    MonsterData magicData;
    MonsterData bossPhaseOne;
    MonsterData bossPhaseTwo;
    public float swordManDamage;
    private void Start()
    {
        monsterDataToJson = new MonsterDataToJson();
        monsterDataToJson.Load();
        monsterDataDic = monsterDataToJson.readFromJson;
        swordManData = monsterDataDic["�ҵ��"];
        magicData = monsterDataDic["������"];
        bossPhaseOne = monsterDataDic["��ġ��"];
        bossPhaseTwo = monsterDataDic["��ġ��2"];
        bossDatas = bossPhaseOne.skills;
        bossTwoDatas = bossPhaseTwo.skills;
        Debug.Log("����1�� ��ų ��Ÿ�� " + bossDatas[0].coolTime);
        
    }




}
