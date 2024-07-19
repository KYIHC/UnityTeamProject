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
        swordManData = monsterDataDic["소드맨"];
        magicData = monsterDataDic["매지션"];
        bossPhaseOne = monsterDataDic["리치왕"];
        bossPhaseTwo = monsterDataDic["리치왕2"];
        bossDatas = bossPhaseOne.skills;
        bossTwoDatas = bossPhaseTwo.skills;
        Debug.Log("보스1의 스킬 쿨타임 " + bossDatas[0].coolTime);
        
    }




}
