using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCaller : MonoBehaviour
{
    private WindowManager _windowManager;

    private void Start()
    {
        _windowManager = GameManager.Instance.GetComponentInChildren<WindowManager>();
    }

    public void ShowWindow(string windowName)
    {
        _windowManager.ShowWindow(windowName);
    }
    
    public void ShowDialogue(string dialogueName)
    {
        _windowManager.ShowDialogue(dialogueName);
    }
    
    public void HideDialogues()
    {
        _windowManager.HideDialogues();
    }
}