using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : ScriptableObject
{
    public virtual void cast(CharacterSlot caster, CharacterSlot target)
    {
    }

    public virtual void cast(
        CharacterSlot caster,
        CharacterSlot target,
        List<float> values
    )
    {
    }
}
