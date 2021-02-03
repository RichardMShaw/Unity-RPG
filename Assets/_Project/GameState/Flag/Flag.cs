using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Flag
{
    public string name;

    public int value;

    public Flag(string _name, int _value)
    {
        name = _name;
        value = _value;
    }
}
