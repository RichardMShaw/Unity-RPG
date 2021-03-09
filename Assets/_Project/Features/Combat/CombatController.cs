using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatState
{
    PlayerMenu,
    SelectSkill,
    SelectTarget
}

[
    CreateAssetMenu(
        fileName = "CombatManager",
        menuName = "Managers/Combat",
        order = 0)
]
public class CombatController : ScriptableObject
{
    public Skill skill;

    public CharacterSlot caster;

    public CharacterSlot target;

    private CombatState state;

    public void onSkillClicked(Skill _skill)
    {
        if (state != CombatState.SelectSkill)
        {
            return;
        }

        skill = _skill;

        state = CombatState.SelectTarget;
    }

    public void onEnemyClicked(EnemySlot _target)
    {
        if (state == CombatState.SelectTarget)
        {
            target = _target;
        }
        else if (state == CombatState.PlayerMenu)
        {
        }
    }
}
