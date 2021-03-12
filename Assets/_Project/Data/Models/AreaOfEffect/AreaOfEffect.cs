using System;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "New AOE",
        menuName = "Combat/Area Of Effect",
        order = 0)
]
public class AreaOfEffect : ScriptableObject
{
    public virtual void cast(
        CharacterSlot caster,
        CharacterSlot target,
        SkillEffect skillEffect
    )
    {
    }

    public virtual void cast(
        CharacterSlot caster,
        CharacterSlot target,
        SkillEffect skillEffect,
        List<float> potencies
    )
    {
    }
}
