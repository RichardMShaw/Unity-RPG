using System;
using System.Collections.Generic;
using UnityEngine;

public class TeamHandler
{
    public AllyTeam allyTeam;

    public EnemyTeam enemyTeam;

    public void recycleAll()
    {
        allyTeam.recycleAll();
        enemyTeam.recycleAll();
    }

    public void copyAllySlot(AllySlot slot)
    {
    }

    public void setAllyTeam()
    {
    }

    public void setEnemyTeam()
    {
    }
}
