using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    public static SoundManager instance;
    public AudioSource musicSource;
    private AudioSource sfxSource;
    public AudioClip PlayerAttackClip;
    public AudioClip SkillStrikeClip;
    public AudioClip BuffClip;
    public AudioClip kickClip;
    public AudioClip walkClip;
    


    private void Awake()
    {


        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        sfxSource = gameObject.AddComponent<AudioSource>();


    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void PlayAttackSound()
    {
        sfxSource.PlayOneShot(PlayerAttackClip);
    }

    public void PlaySkillSound()
    {
        sfxSource.PlayOneShot(SkillStrikeClip);
    }

    public void PlayBuffSound()
    {
        sfxSource.PlayOneShot(BuffClip);
    }

    public void PlayKickSound()
    {
        sfxSource.PlayOneShot(kickClip);
    }

    

    public void PlayWalkingSound()
    {
        if (!sfxSource.isPlaying)
        {
            sfxSource.clip = walkClip;
            sfxSource.loop = true;
            sfxSource.Play();
        }
    }

    public void StopWalkingSound()
    {
        if (sfxSource.clip == walkClip)
        {
            sfxSource.Stop();
            sfxSource.loop = false;
            sfxSource.clip = null;
        }
    }


}
