using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSlotHandler
{
    public Stack<AllySlot> reservedAllySlots;

    public Stack<EnemySlot> reservedEnemySlots;

    private List<AllySlot> frontRowAllies;

    private List<AllySlot> backRowAllies;

    private List<EnemySlot> frontRowEnemies;

    private List<EnemySlot> backRowEnemies;

    public void recycleAll()
    {
        for (int i = frontRowAllies.Count; i > -1; i--)
        {
            reservedAllySlots.Push(frontRowAllies[i]);
        }
        frontRowAllies.Clear();
        for (int i = backRowAllies.Count; i > -1; i--)
        {
            reservedAllySlots.Push(backRowAllies[i]);
        }
        backRowAllies.Clear();
        for (int i = frontRowEnemies.Count; i > -1; i--)
        {
            reservedEnemySlots.Push(frontRowEnemies[i]);
        }
        frontRowEnemies.Clear();
        for (int i = backRowEnemies.Count; i > -1; i--)
        {
            reservedEnemySlots.Push(backRowEnemies[i]);
        }
        backRowEnemies.Clear();
    }

    public void copyAllySlot(AllySlot slot){

    }

    public AllySlot addAllyToFrontRow(Ally ally)
    {
        if (reservedAllySlots.Count < 1)
        {
            return null;
        }
        AllySlot newAlly;
        if (frontRowAllies.Count > 2)
        {
            if (backRowAllies.Count > 2)
            {
                return null;
            }
            newAlly = reservedAllySlots.Pop();
            newAlly.setBaseAlly (ally);
            backRowAllies.Add (newAlly);

            return newAlly;
        }
        newAlly = reservedAllySlots.Pop();
        newAlly.setBaseAlly (ally);
        frontRowAllies.Add (newAlly);

        return newAlly;
    }

    public AllySlot addAllyToBackRow(Ally ally)
    {
        if (reservedAllySlots.Count < 1)
        {
            return null;
        }

        AllySlot newAlly;
        if (backRowAllies.Count > 2)
        {
            if (frontRowAllies.Count > 2)
            {
                return null;
            }
            newAlly = reservedAllySlots.Pop();
            newAlly.setBaseAlly (ally);
            frontRowAllies.Add (newAlly);

            return newAlly;
        }
        newAlly = reservedAllySlots.Pop();
        newAlly.setBaseAlly (ally);
        frontRowAllies.Add (newAlly);

        return newAlly;
    }

    public bool recycleAllySlot(AllySlot slot)
    {
        if (!frontRowAllies.Remove(slot))
        {
            if (!backRowAllies.Remove(slot))
            {
                return false;
            }
        }
        reservedAllySlots.Push (slot);
        return true;
    }

    public EnemySlot addEnemyToFrontRow(Enemy enemy)
    {
        if (reservedEnemySlots.Count < 1)
        {
            return null;
        }

        EnemySlot newEnemy;
        if (frontRowAllies.Count > 2)
        {
            if (backRowEnemies.Count > 2)
            {
                return null;
            }
            newEnemy = reservedEnemySlots.Pop();
            newEnemy.setBaseEnemy (enemy);
            backRowEnemies.Add (newEnemy);

            return newEnemy;
        }
        newEnemy = reservedEnemySlots.Pop();
        newEnemy.setBaseEnemy (enemy);
        frontRowEnemies.Add (newEnemy);

        return newEnemy;
    }

    public EnemySlot addEnemyToBackRow(Enemy enemy)
    {
        if (reservedEnemySlots.Count < 1)
        {
            return null;
        }

        EnemySlot newEnemy;
        if (backRowEnemies.Count > 2)
        {
            if (frontRowEnemies.Count > 2)
            {
                return null;
            }
            newEnemy = reservedEnemySlots.Pop();
            newEnemy.setBaseEnemy (enemy);
            frontRowEnemies.Add (newEnemy);

            return newEnemy;
        }
        newEnemy = reservedEnemySlots.Pop();
        newEnemy.setBaseEnemy (enemy);
        backRowEnemies.Add (newEnemy);

        return newEnemy;
    }

    public bool recycleEnemySlot(EnemySlot slot)
    {
        if (!frontRowEnemies.Remove(slot))
        {
            if (!backRowEnemies.Remove(slot))
            {
                return false;
            }
        }
        reservedEnemySlots.Push (slot);
        return true;
    }
}
