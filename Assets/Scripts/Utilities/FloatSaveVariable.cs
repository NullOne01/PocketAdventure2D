using UnityEngine;

public class FloatSaveVariable : SaveStateVariable<float>
{
    public override float Value
    {
        get => PlayerPrefs.GetFloat(_key, _defaultValue);
        set => PlayerPrefs.SetFloat(_key, value);
    }

    public FloatSaveVariable(string key, float defaultValue) : base(key, defaultValue)
    {
    }
}