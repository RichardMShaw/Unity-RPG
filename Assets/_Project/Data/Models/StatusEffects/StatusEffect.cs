using System;
using UnityEngine;
using UnityEngine.UI;

public enum StatusEffectType
{
    None,
    Buff,
    Debuff,
    Invisible
}

[Serializable]
public class StatusEffect : ScriptableObject
{
    public string id;

    public StatusEffectType type;

    public Texture icon;

    //There can only be one temporary status effect slot
    public bool unique;

    [TextArea(3, 10)]
    public string description;

    public CharacterEvents events;

    public virtual TemporaryStatusEffectSlot
    compareTemporaryStatusEffectSlots(
        TemporaryStatusEffectSlot _old,
        TemporaryStatusEffectSlot _new
    )
    {
        return null;
    }

    public string print()
    {
        return description;
    }

    //Only apply stat modifications in this function
    public virtual void onAdd(CharacterSlot target)
    {
    }

    //Remove all of the modifications above
    public virtual void onRemove(CharacterSlot target)
    {
    }
}
