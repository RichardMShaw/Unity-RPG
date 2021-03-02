using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "Regen",
        menuName = "Combat/Status/Regen",
        order = 0)
]
public class Regen : StatusEffect
{
    public Skill turnEndSkill;

    private void Awake()
    {
        type = StatusEffectType.Buff;
    }

    private void OnEnable()
    {
        events.onTurnEnd += onTurnEnd;
    }

    public void onTurnEnd(CharacterSlot caster)
    {
        GameEvents
            .events
            .addSkillToQueue(new SkillQueueSlot(turnEndSkill, caster, caster));
    }
}
