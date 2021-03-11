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
    public CombatViewer viewer;

    private CombatState state;

    private CombatMenuState menuState;

    private Field field;

    public List<AllySlot> reservedAllies;

    public List<EnemySlot> reservedEnemies;

    private List<AllySlot> frontRowAllies;

    private List<AllySlot> backRowAllies;

    private List<EnemySlot> frontRowEnemies;

    private List<EnemySlot> backRowEnemies;

    private EnemyTeam enemyTeam;

    public Skill skill;

    public CharacterSlot caster;

    public CharacterSlot target;

    private void onBattleStart()
    {
        var list = field.getAllCharacterSlots();
        int len = list.Count;
        for (int i = 0; i < len; i++)
        {
            CharacterSlot slot = list[i];
            list[i].getEvents().battleStart(slot);
        }

        viewer.onBattleStart (field);
    }

    private void onState()
    {
        switch (state)
        {
            case CombatState.BattleStart:
                onBattleStart();
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
