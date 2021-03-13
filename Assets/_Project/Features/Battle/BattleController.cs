using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    EnterBattle,
    BattleStart,
    TurnStart,
    HeroTurn,
    EnemyTurn,
    TurnEnd,
    BattleEnd
}

public enum BattleMenuState
{
    Disabled,
    SelectSkill,
    SelectTarget,
    StatusEffectOverlay
}

[
    CreateAssetMenu(
        fileName = "BattleManager",
        menuName = "Managers/Battle",
        order = 0)
]
public class BattleController : ScriptableObject
{
    public BattleViewer viewer;

    private BattleState state;

    private BattleMenuState menuState;

    private Field field;

    public TeamHandler teamHandler;

    public Skill skill;

    public CharacterSlot caster;

    public CharacterSlot target;

    private void onEnterBattle(BattleLoadout loadout)
    {
        field = loadout.field;
        viewer.setBackground(field.background);
    }

    private void onBattleStart()
    {
    }

    private void onState()
    {
        switch (state)
        {
            case BattleState.BattleStart:
                onBattleStart();
                break;
            case BattleState.TurnStart:
                state = BattleState.HeroTurn;
                break;
            case BattleState.HeroTurn:
                state = BattleState.EnemyTurn;
                break;
            case BattleState.EnemyTurn:
                state = BattleState.TurnEnd;
                break;
            case BattleState.TurnEnd:
                state = BattleState.TurnStart;
                break;
            default:
                state = BattleState.BattleEnd;
                break;
        }
    }

    private void nextState()
    {
        switch (state)
        {
            case BattleState.BattleStart:
                state = BattleState.TurnStart;
                break;
            case BattleState.TurnStart:
                state = BattleState.HeroTurn;
                break;
            case BattleState.HeroTurn:
                state = BattleState.EnemyTurn;
                break;
            case BattleState.EnemyTurn:
                state = BattleState.TurnEnd;
                break;
            case BattleState.TurnEnd:
                state = BattleState.TurnStart;
                break;
            default:
                state = BattleState.BattleEnd;
                break;
        }
    }

    public void onSkillClicked(Skill _skill)
    {
        if (menuState != BattleMenuState.SelectSkill)
        {
            return;
        }

        skill = _skill;

        menuState = BattleMenuState.SelectTarget;
    }

    public void onEnemyClicked(EnemySlot enemySlot)
    {
        if (menuState == BattleMenuState.SelectTarget)
        {
            target = enemySlot;
            GameEvents
                .events
                .addSkillToQueue(new SkillQueueSlot(caster, target, skill));
        }
        else if (menuState == BattleMenuState.SelectSkill)
        {
        }
    }

    public void onHeroClicked(HeroSlot heroSlot)
    {
        if (menuState == BattleMenuState.SelectSkill)
        {
            target = heroSlot;
        }
        if (menuState == BattleMenuState.SelectTarget)
        {
            target = heroSlot;
        }
    }
}
