using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    public static SoundManager instance;

    public AudioSource musicSource;

    public AudioSource btnsource;

    public GameObject soundPanel;

    

    private void Awake()
    {


        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void OnSfx()
    {
        btnsource.Play();
    }

    public void gameinSoundSetting()
    {
        soundPanel.SetActive(true);

    }
}
