using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSlot : ScriptableObject
{
    public string label;

    [Header("Stats")]
    public int level;

    public int health;

    public Stats stats;

    [Header("Status Effects")]
    public CharacterEvents events;

    public List<TemporaryStatusEffectSlot> temporaryStatusEffectSlots;

    public virtual List<StatusEffectSlot> passives
    {
        get
        {
            return null;
        }
    }

    public List<StatusEffectTag> tags;

    public virtual bool
    addTemporaryStatusEffectSlot(TemporaryStatusEffectSlot slot)
    {
        if (slot.statusEffect.unique)
        {
            var old =
                temporaryStatusEffectSlots
                    .Find(s => s.statusEffect == slot.statusEffect);
            if (old != null)
            {
                var temp = old.compareNewSlot(slot);
                if (temp == old || temp == null)
                {
                    return false;
                }
                removeTemporaryStatusEffectSlot (old);
            }
        }
        slot.statusEffect.onAdd(this);
        events += slot.statusEffect.events;
        temporaryStatusEffectSlots.Add (slot);

        return true;
    }

    public virtual void removeTemporaryStatusEffectSlot(
        TemporaryStatusEffectSlot slot
    )
    {
        slot.statusEffect.onRemove(this);
        events -= slot.statusEffect.events;
        temporaryStatusEffectSlots.Remove (slot);
    }
}
