using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderViewer : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        AudioManager audioManager = GameManager.Instance.GetComponentInChildren<AudioManager>();
        slider.value = audioManager.Volume.Value;
    }
}