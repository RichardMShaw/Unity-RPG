using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeam
{
    public Queue<EnemySlot> reservedEnemySlots;

    public List<EnemySlot> frontRowEnemies;

    public List<EnemySlot> backRowEnemies;

    public void recycleAll()
    {
        for (int i = frontRowEnemies.Count; i > -1; i--)
        {
            reservedEnemySlots.Enqueue(frontRowEnemies[i]);
        }
        frontRowEnemies.Clear();
        for (int i = backRowEnemies.Count; i > -1; i--)
        {
            reservedEnemySlots.Enqueue(backRowEnemies[i]);
        }
        backRowEnemies.Clear();
    }

    public EnemySlot addEnemyToFrontRow(Enemy enemy)
    {
        if (reservedEnemySlots.Count < 1)
        {
            return null;
        }

        EnemySlot newEnemy;
        if (frontRowEnemies.Count > 2)
        {
            if (backRowEnemies.Count > 2)
            {
                return null;
            }
            newEnemy = reservedEnemySlots.Dequeue();
            newEnemy.setBaseEnemy (enemy);
            backRowEnemies.Add (newEnemy);

            return newEnemy;
        }
        newEnemy = reservedEnemySlots.Dequeue();
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
            newEnemy = reservedEnemySlots.Dequeue();
            newEnemy.setBaseEnemy (enemy);
            frontRowEnemies.Add (newEnemy);

            return newEnemy;
        }
        newEnemy = reservedEnemySlots.Dequeue();
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
        reservedEnemySlots.Enqueue (slot);
        return true;
    }
}
