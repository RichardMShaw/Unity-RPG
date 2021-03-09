using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatusEffectSlot
{
    public StatusEffect statusEffect;

    public List<float> values;

    public StatusEffectType type
    {
        get
        {
            return statusEffect.type;
        }
    }

    public string print()
    {
        return statusEffect.print();
    }

    public StatusEffectType getType()
    {
        return statusEffect.type;
    }
}
