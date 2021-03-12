using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Row
{
    Front,
    Back
}

[
    CreateAssetMenu(
        fileName = "CharacterBase ",
        menuName = "Combat/CharacterBase Slot",
        order = 0)
]
public class CharacterSlot : ScriptableObject
{
    [Header("Base Character")]
    [SerializeField]
    public Character character;

    [Header("Position")]
    public Row row;

    public int index;

    [Header("Stats")]
    public int level;

    public int health;

    public Stats stats;

    [Header("Status Effects")]
    public List<TemporaryStatusEffectSlot> temporaySlots;

    public List<StatusEffectSlot> passiveSlots;

    public List<StatusEffectTag> tags;

    public CharacterEvents events;

    public virtual bool
    addTemporaryStatusEffectSlot(TemporaryStatusEffectSlot slot)
    {
        if (slot.statusEffect.unique)
        {
            var old =
                temporaySlots.Find(s => s.statusEffect == slot.statusEffect);
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
        temporaySlots.Add (slot);

        return true;
    }

    public virtual void removeTemporaryStatusEffectSlot(
        TemporaryStatusEffectSlot slot
    )
    {
        slot.statusEffect.onRemove(this);
        events -= slot.statusEffect.events;
        temporaySlots.Remove (slot);
    }

    public virtual void addStatusEffectSlot(StatusEffectSlot slot)
    {
        slot.statusEffect.onAdd(this);
        events += slot.statusEffect.events;
        passiveSlots.Add (slot);
    }

    public void removeStatusEffectSlot(StatusEffectSlot slot)
    {
        slot.statusEffect.onRemove(this);
        events -= slot.statusEffect.events;
        passiveSlots.Remove (slot);
    }
}
