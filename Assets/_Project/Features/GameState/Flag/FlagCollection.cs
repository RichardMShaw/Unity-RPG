using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCollection
{
    private List<Flag> flagState;

    public Dictionary<string, Flag> flags;

    public Flag findOrCreate(string name)
    {
        name = name.ToLower();
        if (!flags.ContainsKey(name))
        {
            Flag flag = new Flag(name, 0);
            flags.Add (name, flag);
            flagState.Add (flag);
        }

        return flags[name];
    }

    public Flag set(string name, int value)
    {
        name = name.ToLower();
        Flag flag = findOrCreate(name);
        flag.value = value;
        return flag;
    }

    public Flag change(string name, int value)
    {
        name = name.ToLower();
        Flag flag = findOrCreate(name);
        flag.value += value;
        return flag;
    }

    public Flag find(string name)
    {
        name = name.ToLower();
        return findOrCreate(name);
    }

    public void get(string name)
    {
        Flag flag = find(name);
        Debug.Log(flag.value.ToString());
    }

    public void load(List<Flag> _flagState)
    {
        flagState = _flagState;
        flags.Clear();
        for (int i = flagState.Count - 1; i > -1; i--)
        {
            Flag flag = flagState[i];
            flags.Add(flag.name.ToLower(), flag);
        }
    }

    public FlagCollection(List<Flag> _flagState)
    {
        flagState = _flagState;
        flags = new Dictionary<string, Flag>();
        for (int i = flagState.Count - 1; i > -1; i--)
        {
            Flag flag = flagState[i];
            flags.Add(flag.name.ToLower(), flag);
        }
    }
}
