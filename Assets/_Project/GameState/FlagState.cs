using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "FlagState",
        menuName = "Unity-RPG/FlagState",
        order = 0)
]
public class FlagState : ScriptableObject
{
    [Serializable]
    public struct Flag
    {
        public string key;

        public int val;

        public Flag(string key, int val)
        {
            this.key = key;
            this.val = val;
        }
    }

    public List<Flag> flags = new List<Flag>();

    private Dictionary<string, int> index;

    private void checkKey(string key)
    {
        if (!index.ContainsKey(key))
        {
            flags.Add(new Flag(key, 0));
            index.Add(key, flags.Count - 1);
        }
    }

    public void changeVal(string key, int val)
    {
        checkKey (key);
        int i = index[key];
        var flag = flags[i];
        flag.val += val;
        flags[i] = flag;
    }

    public void setVal(string key, int val)
    {
        checkKey (key);
        int i = index[key];
        var flag = flags[i];
        flag.val = val;
        flags[i] = flag;
    }

    public int getVal(string key)
    {
        checkKey (key);
        return flags[index[key]].val;
    }

    public void compareFlagtoVal(
        string key,
        string op,
        int val,
        BooleanHolder obj
    )
    {
        if (!obj.boolean)
        {
            return;
        }
        int value = getVal(key);
        switch (op)
        {
            case "<":
                obj.boolean = value < val;
                return;
            case "==":
                obj.boolean = value == val;
                return;
            case ">":
                obj.boolean = value > val;
                return;
            case "<=":
                obj.boolean = value <= val;
                return;
            case ">=":
                obj.boolean = value >= val;
                return;
        }
    }

    public void compareFlagtoFlag(
        string key1,
        string op,
        string key2,
        BooleanHolder obj
    )
    {
        if (!obj.boolean)
        {
            return;
        }
        int value1 = getVal(key1);
        int value2 = getVal(key2);
        switch (op)
        {
            case "<":
                obj.boolean = value1 < value2;
                return;
            case "==":
                obj.boolean = value1 == value2;
                return;
            case ">":
                obj.boolean = value1 > value2;
                return;
            case "<=":
                obj.boolean = value1 <= value2;
                return;
            case ">=":
                obj.boolean = value1 >= value2;
                return;
        }
    }

    public bool compareTwineFlagtoFlag(string key1, string op, string key2)
    {
        int value1 = getVal(key1);
        int value2 = getVal(key2);
        switch (op)
        {
            case "<":
                return value1 < value2;
            case "==":
                return value1 == value2;
            case ">":
                return value1 > value2;
            case "<=":
                return value1 <= value2;
            case ">=":
                return value1 >= value2;
        }
        return false;
    }

    public bool compareTwineFlagtoVal(
        string key,
        string op,
        int val
    )
    {
        int value = getVal(key);
        switch (op)
        {
            case "<":
                return value < val;
            case "==":
                return value == val;
            case ">":
                return value > val;
            case "<=":
                return value <= val;
            case ">=":
                return value >= val;
        }
        return false;
    }

    public void Start()
    {
        index = new Dictionary<string, int>();
        for (int i = flags.Count - 1; i > -1; i--)
        {
            index.Add(flags[i].key, i);
        }
    }
}
