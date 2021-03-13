using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Row
{
    Front,
    Back
}

public class CharacterSlot : ScriptableObject
{
    public string label;

    [Header("Stats")]
    public int level;

    public int health;

    public Stats stats;

    [Header("Status Effects")]
    public List<TemporaryStatusEffectSlot> temporayStatusEffectSlots;

    public List<StatusEffectSlot> passives;

    public List<StatusEffectTag> tags;

    public CharacterEvents events;

    public virtual bool
    addTemporaryStatusEffectSlot(TemporaryStatusEffectSlot slot)
    {
        if (slot.statusEffect.unique)
        {
            var old =
                temporayStatusEffectSlots
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
        temporayStatusEffectSlots.Add (slot);

        return true;
    }

    public virtual void removeTemporaryStatusEffectSlot(
        TemporaryStatusEffectSlot slot
    )
    {
        slot.statusEffect.onRemove(this);
        events -= slot.statusEffect.events;
        temporayStatusEffectSlots.Remove (slot);
    }

    public virtual void addStatusEffectSlot(StatusEffectSlot slot)
    {
        slot.statusEffect.onAdd(this);
        events += slot.statusEffect.events;
        passives.Add (slot);
    }

    public void removeStatusEffectSlot(StatusEffectSlot slot)
    {
        slot.statusEffect.onRemove(this);
        events -= slot.statusEffect.events;
        passives.Remove (slot);
    }
}
