using System.Collections.Generic;

public class StatusEffectSkillQueueSlot : SkillQueueSlot
{
    List<float> values;

    public StatusEffectSkillQueueSlot(
        CharacterSlot _caster,
        CharacterSlot _target,
        Skill _skill,
        List<float> _values
    ) :
        base(_caster, _target, _skill)
    {
        values = _values;
    }
}
