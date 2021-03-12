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

    public Sprite icon;

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

    public void onAdd(CharacterSlot target)
    {
    }

    public void onRemove(CharacterSlot target)
    {
    }
}
