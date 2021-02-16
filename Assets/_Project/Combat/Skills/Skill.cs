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

    public SkillType type = SkillType.None;

    public string description;

    public bool visible = false;

    public List<SkillRequirement> requirements;

    public virtual void use(CharacterSlot caster, CharacterSlot target)
    {
        Debug.Log("There is no skill. Shi-neh");
    }
}
