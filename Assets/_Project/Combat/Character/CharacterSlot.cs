using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterSlot
{
    [SerializeField]
    [Header("Base Character")]
    public Character character;

    [Header("Stats")]
    public int level;

    public Health health;

    public MaxHealth maxHealth;

    public Attack attack;

    public CharacterEvents events;

    [Header("Status Effects")]
    public List<StatusEffectSlot> status;

    public virtual void refreshStatusEffectSlots(){
        events.clear();
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
