using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private List<Window> windows;
    [SerializeField] private List<Dialogue> dialogues;

    private StringSaveVariable currentWindowName = new StringSaveVariable("CurrentWindowName", null);
    private StringSaveVariable currentDialogueName = new StringSaveVariable("CurrentDialogueName", null);

    private void Awake()
    {
        RefreshAll();
    }

    public void ShowWindow(Window window)
    {
        if (window == null || !windows.Contains(window))
        {
            throw new ArgumentException("Argument is not window");
        }

        currentWindowName.Value = window.ScreenName;
        RefreshAll();
    }

    public void ShowWindow(string windowName)
    {
        Window window = windows.Find(o => o.ScreenName == windowName);
        ShowWindow(window);
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        if (dialogue == null || !dialogues.Contains(dialogue))
        {
            throw new ArgumentException("Argument is not dialogue");
        }

        currentDialogueName.Value = dialogue.ScreenName;
        RefreshAll();
    }

    public void ShowDialogue(string dialogueName)
    {
        Dialogue dialogue = dialogues.Find(o => o.ScreenName == dialogueName);
        ShowDialogue(dialogue);
    }

    public void HideDialogues()
    {
        currentDialogueName.Value = null;
        RefreshAll();
    }

    private void RefreshAll()
    {
        windows.ForEach(o => o.gameObject.SetActive(false));
        dialogues.ForEach(o => o.gameObject.SetActive(false));

        if (string.IsNullOrEmpty(currentWindowName.Value))
        {
            currentWindowName.Value = windows[0].ScreenName;
        }

        windows.Find(o => o.ScreenName == currentWindowName.Value).gameObject.SetActive(true);

        if (!string.IsNullOrEmpty(currentDialogueName.Value))
        {
            dialogues.Find(o => o.ScreenName == currentDialogueName.Value).gameObject.SetActive(true);
        }
    }
}