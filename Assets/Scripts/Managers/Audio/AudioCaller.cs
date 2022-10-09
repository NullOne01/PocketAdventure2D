using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCaller : MonoBehaviour
{
    public void SetBackgroundVolume(float value)
    {
        AudioManager audioManager = GameManager.Instance.GetComponentInChildren<AudioManager>();
        audioManager.SetBackMusicVolume(value);
    }
}