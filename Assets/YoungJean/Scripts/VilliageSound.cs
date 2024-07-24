using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilliageSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip villiage;

    public void Start()
    {
        audioSource = SoundManager.instance.musicSource;
        audioSource.clip = villiage;
        audioSource.Play();
    }
    
}
