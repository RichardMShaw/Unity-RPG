using System;
using UnityEngine;

public class SkillQueueSlot
{
    private CharacterSlot caster;

    private CharacterSlot target;

    private Skill skill;

    public virtual void cast()
    {
        skill.cast (caster, target);
    }

    public SkillQueueSlot(
        CharacterSlot _caster,
        CharacterSlot _target,
        Skill _skill
    )
    {
        caster = _caster;
        target = _target;
        skill = _skill;
    }
}
