using System;
using UnityEngine;

[Serializable]
public class StatusEffectSlot
{
    public StatusEffect effect;

    public CharacterSlot parent;

    public int duration;

    public int dispel;
    public StatusEffectSlot(
        CharacterSlot _parent,
        StatusEffect _effect,
        int _duration,
        int _dispel
    )
    {
        parent = _parent;
        effect = _effect;
        duration = _duration;
        dispel = _dispel;
    }
}
