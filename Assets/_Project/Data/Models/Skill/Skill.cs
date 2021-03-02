using System;
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

[Serializable]
public class Skill : ScriptableObject
{
    public string id;

    public string label;

    public SkillType type = SkillType.None;

    [TextArea(20, 3)]
    public string description;

    public List<StatusEffectTag> restrictions;

    public List<StatusEffectTag> requirements;

    public bool isValid(CharacterSlot caster)
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

        return true;
    }

    public virtual void effect(CharacterSlot caster, CharacterSlot target)
    {
        Debug.Log("There is no skill. Shi-neh");
    }

    public void cast(CharacterSlot caster, CharacterSlot target)
    {
        if (isValid(caster))
        {
            effect (caster, target);
        }
    }
}
