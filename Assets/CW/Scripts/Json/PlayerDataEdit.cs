using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(PlayerJson))]
public class PlayerDataEdit : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlayerJson playerData = target as PlayerJson;

        if(GUILayout.Button("Save"))
        {
            playerData.Save();
        }

        if(GUILayout.Button("Load"))
        {
            playerData.Load();
        }
    }
}
