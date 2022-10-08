using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _backgroundMusicSource;
    
    void Awake()
    {
        _backgroundMusicSource = GetComponent<AudioSource>();
        SetUpBackMusic();
    }

    private void SetUpBackMusic()
    {
        float volume = PlayerPrefs.GetFloat("BackgroundMusicVolume", 1f);
        _backgroundMusicSource.volume = volume;
    }

    public void SetBackMusicVolume(float newValue)
    {
        PlayerPrefs.SetFloat("BackgroundMusicVolume", newValue);
        _backgroundMusicSource.volume = newValue;
    }
}
