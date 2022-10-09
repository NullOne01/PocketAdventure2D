using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _backgroundMusicSource;
    private FloatSaveVariable _volume = new FloatSaveVariable("BackgroundMusicVolume", 1f);
    
    void Awake()
    {
        _backgroundMusicSource = GetComponent<AudioSource>();
        _backgroundMusicSource.volume = _volume.Value;
    }

    public void SetBackMusicVolume(float newValue)
    {
        _volume.Value = newValue;
        _backgroundMusicSource.volume = newValue;
    }
}
