using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ScriptableObject
{
    [Header("Meta")]
    public string id;

    public string label;

    [Header("Stats")]
    public int level;

    public float health;

    public float maxHealth;

    public float attack;

    [Header("Status Effects")]
    [SerializeField]
    public List<StatusEffectSlot> status;
}
