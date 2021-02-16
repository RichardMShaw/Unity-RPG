using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Row
{
    Front,
    Back
}

[
    CreateAssetMenu(
        fileName = "Character",
        menuName = "Combat/CharacterSlot",
        order = 0)
]
public class CharacterSlot : ScriptableObject
{
    [Header("Base Character")]
    [SerializeField]
    public Character character;

    [Header("Position")]
    public Row row;

    public int index;

    [Header("Stats")]
    public int level;

    public Health health;

    public MaxHealth maxHealth;

    public Attack attack;

    public CharacterEvents events;

    [Header("Status Effects")]
    public List<StatusEffectSlot> status;

    public virtual void loadBaseCharacter()
    {
        level = character.level;
        health.baseValue = character.health;
        maxHealth.baseValue = character.maxHealth;
        attack.baseValue = character.attack;
        if (status != null)
        {
            status.Clear();
        }
        status = new List<StatusEffectSlot>(character.status);
    }

    public virtual void refreshStatusEffectSlots()
    {
        events.clear();
        int len = status.Count;
        for (int i = 0; i < len; i++)
        {
            StatusEffectSlot slot = status[i];
            events += slot.effect.events;
        }
    }

    public virtual void addStatusEffectSlot(StatusEffectSlot slot)
    {
        events += slot.effect.events;
        status.Add (slot);
    }

    public virtual void removeStatusEffectSlot(StatusEffectSlot slot)
    {
        events -= slot.effect.events;
        status.Remove (slot);
    }
}
