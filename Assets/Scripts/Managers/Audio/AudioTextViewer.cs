using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioTextViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    private string _baseText;

    private void Awake()
    {
        _baseText = _textMeshProUGUI.text;
    }

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        AudioManager audioManager = GameManager.Instance.GetComponentInChildren<AudioManager>();
        int volume = (int)(audioManager.Volume.Value * 100);
        _textMeshProUGUI.text = string.Format(_baseText, volume);
    }
}