using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatState
{
    BattleStart,
    TurnStart,
    AllyTurn,
    EnemyTurn,
    TurnEnd,
    BattleEnd
}

public enum CombatMenuState
{
    Disabled,
    Menu,
    Skill,
    Target
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

    private CombatMenuState menuState;

    private void processBattleStart()
    {
    }

    private void processState()
    {
        switch (state)
        {
            case CombatState.BattleStart:
                processBattleStart();
                break;
            case CombatState.TurnStart:
                state = CombatState.AllyTurn;
                break;
            case CombatState.AllyTurn:
                state = CombatState.EnemyTurn;
                break;
            case CombatState.EnemyTurn:
                state = CombatState.TurnEnd;
                break;
            case CombatState.TurnEnd:
                state = CombatState.TurnStart;
                break;
            default:
                state = CombatState.BattleEnd;
                break;
        }
    }

    private void nextState()
    {
        switch (state)
        {
            case CombatState.BattleStart:
                state = CombatState.TurnStart;
                break;
            case CombatState.TurnStart:
                state = CombatState.AllyTurn;
                break;
            case CombatState.AllyTurn:
                state = CombatState.EnemyTurn;
                break;
            case CombatState.EnemyTurn:
                state = CombatState.TurnEnd;
                break;
            case CombatState.TurnEnd:
                state = CombatState.TurnStart;
                break;
            default:
                state = CombatState.BattleEnd;
                break;
        }
    }

    public void onSkillClicked(Skill _skill)
    {
        if (menuState != CombatMenuState.Skill)
        {
            return;
        }

        skill = _skill;

        menuState = CombatMenuState.Target;
    }

    public void onEnemyClicked(EnemySlot _target)
    {
        if (menuState == CombatMenuState.Target)
        {
            target = _target;
        }
        else if (menuState == CombatMenuState.Menu)
        {
        }
    }
}
