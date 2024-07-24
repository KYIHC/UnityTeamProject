using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSoundManager : MonoBehaviour
{
    public static MSoundManager instance;

    public AudioClip[] monsterAudio;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
   
    }
}
