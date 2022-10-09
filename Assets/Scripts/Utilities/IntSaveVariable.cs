using UnityEngine;

public class IntSaveVariable : SaveStateVariable<int>
{
    public override int Value
    {
        get => PlayerPrefs.GetInt(_key, _defaultValue);
        set => PlayerPrefs.SetInt(_key, value);
    }

    public IntSaveVariable(string key, int defaultValue) : base(key, defaultValue)
    {
    }
}