using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSoundManager : MonoBehaviour
{
    public static MSoundManager instance;

    public AudioClip[] bossAudio;
    public AudioClip[] monsterAudio;
    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }
}
