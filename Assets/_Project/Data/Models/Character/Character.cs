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

    [SerializeField]
    public BaseStats baseStats;

    [Header("Status Effects")]
    [SerializeField]
    public List<StatusEffectSlot> passives;
}
