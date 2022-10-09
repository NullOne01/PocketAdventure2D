using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TryAgainDialogue : Dialogue
{
    [SerializeField] private TextMeshProUGUI statusText;

    private StringSaveVariable _statusStateText = new StringSaveVariable("TryAgainStatus", "Mistake");

    private void Start()
    {
        RefreshText();
    }

    private void RefreshText()
    {
        LocalizationManager localizationManager = GameManager.Instance.GetComponentInChildren<LocalizationManager>();
        statusText.text = localizationManager.GetLocalizedValue(_statusStateText.Value);
    }

    public void UpdateStatus(string newStatus)
    {
        _statusStateText.Value = newStatus;
        RefreshText();
    }
}