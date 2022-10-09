using UnityEngine;

public class StringSaveVariable : SaveStateVariable<string>
{
    public override string Value
    {
        get => PlayerPrefs.GetString(_key, _defaultValue);
        set => PlayerPrefs.SetString(_key, value);
    }

    public StringSaveVariable(string key, string defaultValue) : base(key, defaultValue)
    {
    }
}