using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public FloatSaveVariable Volume { get; set; } = new FloatSaveVariable("BackgroundMusicVolume", 1f);

    private AudioSource _backgroundMusicSource;

    void Awake()
    {
        _backgroundMusicSource = GetComponent<AudioSource>();
        _backgroundMusicSource.volume = Volume.Value;
    }

    public void SetBackMusicVolume(float newValue)
    {
        Volume.Value = newValue;
        _backgroundMusicSource.volume = newValue;
    }
}