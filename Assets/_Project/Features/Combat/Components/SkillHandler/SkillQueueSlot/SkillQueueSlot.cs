using System;
using UnityEngine;

public class SkillQueueSlot
{
    private Skill skill;

    private CharacterSlot caster;

    private CharacterSlot target;

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
