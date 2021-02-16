using System;
using UnityEngine;

[Serializable]
public class StatusEffectSlot
{
    //Reference to the status effect
    public StatusEffect effect;

    //Reference to who inflicted the status effect
    public CharacterSlot caster;

    //How many turns until it is removed. -1 or lower means infinite duration
    public int duration;

    //Can't be removed through skills
    public bool unremovable;

    //Is not removed after combat
    public bool lasting;

    //Is not removed on defeat
    public bool persistance;

    public StatusEffectSlot(
        CharacterSlot _caster,
        StatusEffect _effect,
        int _duration
    )
    {
        caster = _caster;
        effect = _effect;
        duration = _duration;
        unremovable = false;
        lasting = false;
        persistance = false;
    }

    public StatusEffectSlot(
        CharacterSlot _caster,
        StatusEffect _effect,
        int _duration,
        bool _unremovable,
        bool _lasting,
        bool _persistance
    )
    {
        caster = _caster;
        effect = _effect;
        duration = _duration;
        unremovable = _unremovable;
        lasting = _lasting;
        persistance = _persistance;
    }
}
