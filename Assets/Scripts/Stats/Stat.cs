﻿using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;

    public int GetValue() {
        return baseValue;
    }

    public void SetValue(int value) {
        baseValue = value;
    }
}
