using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    private Dictionary<string, string> Russian = new Dictionary<string, string>()
    {
        {"Victory", "Победа"},
        {"Mistake", "Ошибка"}
    };

    public string GetLocalizedValue(string key)
    {
        return Russian[key];
    }
}