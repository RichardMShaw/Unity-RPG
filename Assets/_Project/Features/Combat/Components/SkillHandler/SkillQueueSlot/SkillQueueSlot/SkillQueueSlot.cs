using System;
using UnityEngine;

public class SkillQueueSlot
{
    public Skill skill;

    public CharacterSlot caster;

    public CharacterSlot target;

    public virtual void cast()
    {
        skill.cast (caster, target);
    }

    public SkillQueueSlot(
        Skill _skill,
        CharacterSlot _caster,
        CharacterSlot _target
    )
    {
        skill = _skill;
        caster = _caster;
        target = _target;
    }
}
