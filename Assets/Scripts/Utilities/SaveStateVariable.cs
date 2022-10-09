using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStateVariable<T>
{
    protected string _key;
    protected T _defaultValue;

    public virtual T Value
    {
        get => throw new NotImplementedException("Getter is not overriden.");
        set => throw new NotImplementedException("Setter is not overriden.");
    }

    public void DeleteValue()
    {
        PlayerPrefs.DeleteKey(_key);
    }

    public SaveStateVariable(string key, T defaultValue)
    {
        _key = key;
        _defaultValue = defaultValue;
    }
}