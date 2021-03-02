using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatusEffectSlot
{
    public StatusEffect statusEffect;

    public List<float> values;

    public StatusEffectType type {
        get {
            return statusEffect.type;
        }
    }

}
