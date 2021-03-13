using System.Collections.Generic;

public class StatusEffectSkillQueueSlot : SkillQueueSlot
{
    List<float> values;

    public StatusEffectSkillQueueSlot(
        Skill _skill,
        CharacterSlot _caster,
        CharacterSlot _target,
        List<float> _values
    ) :
        base(_skill, _caster, _target)
    {
        values = _values;
    }
}
