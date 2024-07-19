using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerStats : MonoBehaviour
{
    public float Atk;
    public float Def;



    public static PlayerStats instance;

    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
            return;

        }
        instance = this;
    }
}




