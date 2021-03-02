using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterRow
{
    front,
    back
}

public class Character : ScriptableObject
{
    [Header("Meta")]
    public string id;

    public string label;

    [Header("Stats")]
    public int level;

    public Stats stats;

    [Header("Status Effects")]
    [SerializeField]
    public List<StatusEffectSlot> status;

    public CharacterRow row;

    public Field getField()
    {
        return null;
    }
}
