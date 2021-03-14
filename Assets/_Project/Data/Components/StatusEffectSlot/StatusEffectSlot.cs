using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatusEffectSlot
{
    public StatusEffect statusEffect;

    public List<float> values;

    public void onAdd(CharacterSlot target)
    {
        statusEffect.onAdd (target);
    }

    public StatusEffectType type
    {
        get
        {
            return statusEffect.type;
        }
    }

    public CharacterEvents events
    {
        get
        {
            return statusEffect.events;
        }
    }

    public string print()
    {
        return statusEffect.print();
    }
}
