﻿using System;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    None,
    Buff,
    Debuff,
    Attack,
    Heal,
    Field
}

[
    CreateAssetMenu(
        fileName = "A New Skill",
        menuName = "Combat/Skill",
        order = 0)
]
[Serializable]
public class Skill : ScriptableObject
{
    public string id;

    public string label;

    public SkillType type = SkillType.None;

    [TextArea(20, 3)]
    public string description;

    [SerializeField]
    public List<StatusEffectTag> restrictions;

    [SerializeField]
    public List<StatusEffectTag> requirements;

    public Scope scope;

    public SkillEffect skillEffect;

    public virtual bool
    isTargetValid(CharacterSlot caster, CharacterSlot target)
    {
        return scope.isTargetValid(caster, target);
    }

    public virtual bool isCastValid(CharacterSlot caster, CharacterSlot target)
    {
        for (int i = restrictions.Count - 1; i > -1; i--)
        {
            if (caster.tags.Contains(restrictions[i]))
            {
                Debug.Log("Skill could not be cast due to restriction(s).");
                return false;
            }
        }
        for (int i = requirements.Count - 1; i > -1; i--)
        {
            if (!caster.tags.Contains(requirements[i]))
            {
                Debug
                    .Log("Skill could not be cast due to missing requirement(s)");
                return false;
            }
        }
        if (!scope.isTargetValid(caster, target))
        {
            return false;
        }

        return true;
    }

    public virtual void cast(CharacterSlot caster, CharacterSlot target)
    {
        if (isCastValid(caster, target))
        {
            if (skillEffect != null)
            {
                skillEffect.cast (caster, target);
            }
        }
    }

    public virtual void cast(
        CharacterSlot caster,
        CharacterSlot target,
        List<float> values
    )
    {
        if (isCastValid(caster, target))
        {
            if (skillEffect != null)
            {
                skillEffect.cast (caster, target, values);
            }
        }
    }
}
