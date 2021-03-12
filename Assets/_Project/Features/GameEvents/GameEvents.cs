using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents events;

    private void Awake()
    {
        events = this;
    }

    public event Action<BattleLoadout> onEnterBattle;

    public void enterBattle(BattleLoadout loadout)
    {
        if (onEnterBattle != null)
        {
            onEnterBattle (loadout);
        }
    }

    public event Action onBattleStart;

    public void battleStart()
    {
        if (onBattleStart != null)
        {
            onBattleStart();
        }
    }

    public event Action onBattleEnd;

    public void battleEnd()
    {
        if (onBattleEnd != null)
        {
            onBattleEnd();
        }
    }

    public event Action onTurnStart;

    public void turnStart()
    {
        if (onTurnStart != null)
        {
            onTurnStart();
        }
    }

    public event Action onTurnEnd;

    public void turnEnd()
    {
        if (onTurnEnd != null)
        {
            onTurnEnd();
        }
    }

    public event Action<SkillQueueSlot> onAddSkillToQueue;

    public void addSkillToQueue(SkillQueueSlot slot)
    {
        if (onAddSkillToQueue != null)
        {
            onAddSkillToQueue (slot);
        }
    }
}
