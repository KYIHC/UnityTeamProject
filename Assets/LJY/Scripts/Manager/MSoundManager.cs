using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSoundManager : MonoBehaviour
{
    public static MSoundManager instance;

    public AudioClip[] monsterAudio;
<<<<<<< Updated upstream
=======
    public AudioClip[] dungeonBGM;
    public AudioSource audioSource;

>>>>>>> Stashed changes
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
   
    }
}
