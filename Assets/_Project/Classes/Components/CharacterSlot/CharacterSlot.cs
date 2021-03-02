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

    public Stats stats;

    public CharacterEvents events;

    [Header("Status Effects")]
    public List<StatusEffectSlot> status;

    public List<StatusEffectTag> tags;

    public virtual void loadBaseCharacterBase()
    {
    }

    public virtual void refreshStatusEffectSlots()
    {
    }

    public virtual void addTempStatusEffectSlot(TempStatusEffectSlot slot)
    {
    }

    public virtual void removeTempStatusEffectSlot(TempStatusEffectSlot slot)
    {
    }
}
