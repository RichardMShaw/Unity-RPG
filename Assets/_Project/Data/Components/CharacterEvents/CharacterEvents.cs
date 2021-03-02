using System;
using UnityEngine;

public class CharacterEvents
{
    public event Action<CharacterSlot> onBattleStart;

    public void battleStart(CharacterSlot slot)
    {
        if (onBattleStart != null)
        {
            onBattleStart (slot);
        }
    }

    public event Action<CharacterSlot> onBattleEnd;

    public void battleEnd(CharacterSlot slot)
    {
        if (onBattleEnd != null)
        {
            onBattleEnd (slot);
        }
    }

    public event Action<CharacterSlot> onTurnStart;

    public void turnStart(CharacterSlot slot)
    {
        if (onTurnStart != null)
        {
            onTurnStart (slot);
        }
    }

    public event Action<CharacterSlot> onTurnEnd;

    public void turnEnd(CharacterSlot slot)
    {
        if (onTurnEnd != null)
        {
            onTurnEnd (slot);
        }
    }

    public static CharacterEvents
    operator +(CharacterEvents a, CharacterEvents b)
    {
        a.onBattleStart += b.onBattleStart;
        a.onBattleEnd += b.onBattleEnd;
        a.onTurnStart += b.onTurnStart;
        a.onTurnEnd += b.onTurnEnd;
        return a;
    }

    public static CharacterEvents
    operator -(CharacterEvents a, CharacterEvents b)
    {
        a.onBattleStart -= b.onBattleStart;
        a.onBattleEnd -= b.onBattleEnd;
        a.onTurnStart -= b.onTurnStart;
        a.onTurnEnd -= b.onTurnEnd;
        return a;
    }

    public CharacterEvents()
    {
        onBattleStart = null;
        onBattleEnd = null;
        onTurnStart = null;
        onTurnEnd = null;
    }

    public void clear()
    {
        onBattleStart = null;
        onBattleEnd = null;
        onTurnStart = null;
        onTurnEnd = null;
    }
}
