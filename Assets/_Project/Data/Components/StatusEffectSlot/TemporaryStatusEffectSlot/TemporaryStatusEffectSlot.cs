using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TemporaryStatusEffectSlot : StatusEffectSlot
{
    //Reference to who inflicted the status effect
    public CharacterSlot caster;

    //How many turns until it is removed. -1 or lower means infinite duration
    public int duration;

    //Can't be removed through dispel or clear skills
    public bool unremovable;

    //Is not removed after combat
    public bool lasting;

    //Is not removed on defeat
    public bool persistance;

    public TemporaryStatusEffectSlot createClone()
    {
        return new TemporaryStatusEffectSlot(caster,
            statusEffect,
            duration,
            unremovable,
            lasting,
            persistance);
    }

    public TemporaryStatusEffectSlot
    compareNewSlot(TemporaryStatusEffectSlot _new)
    {
        return statusEffect.compareTemporaryStatusEffectSlots(this, _new);
    }

    public TemporaryStatusEffectSlot(
        CharacterSlot _caster,
        StatusEffect _effect,
        int _duration
    )
    {
        caster = _caster;
        statusEffect = _effect;
        duration = _duration;
        unremovable = false;
        lasting = false;
        persistance = false;
    }

    public TemporaryStatusEffectSlot(
        CharacterSlot _caster,
        StatusEffect _effect,
        int _duration,
        bool _unremovable,
        bool _lasting,
        bool _persistance
    )
    {
        caster = _caster;
        statusEffect = _effect;
        duration = _duration;
        unremovable = _unremovable;
        lasting = _lasting;
        persistance = _persistance;
    }
}
