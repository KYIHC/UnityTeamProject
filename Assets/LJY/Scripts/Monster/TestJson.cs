using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJson : MonoBehaviour
{
    MonsterDataToJson monsterDataToJson;
    
    public Dictionary<string, MonsterData> monsterDataDic = new Dictionary<string, MonsterData>();
    public List<SkillData> monsterDatas = new List<SkillData>();

    MonsterData swordManData;
    MonsterData magicData;
    public float swordManDamage;
    private void Start()
    {
        monsterDataToJson = new MonsterDataToJson();
        monsterDataToJson.Load();
        monsterDataDic = monsterDataToJson.readFromJson;
        swordManData = monsterDataDic["�ҵ��"];
        magicData = monsterDataDic["������"];
        monsterDatas = swordManData.skills;
        
        
    }



    public class MonseterTestClass
    {
        private TestJson testJson;
        public float damage;
        private void Start()
        {
            testJson = new TestJson();

            damage = testJson.magicData.damage;
        }
    }
}
