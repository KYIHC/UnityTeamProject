using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(MonsterDataToJson))]
public class PlayerTest : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MonsterDataToJson monsterData = target as MonsterDataToJson;

        if (GUILayout.Button("Save"))
        {
            Debug.Log("Save");
            monsterData.Save();
        }
        if (GUILayout.Button("Load"))
        {
            Debug.Log("Load");
            monsterData.Load();
        }
    }



}
