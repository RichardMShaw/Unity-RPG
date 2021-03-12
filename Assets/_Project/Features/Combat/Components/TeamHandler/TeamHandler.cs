using System;
using System.Collections.Generic;
using UnityEngine;

public class TeamHandler
{
    public HeroTeam heroTeam;

    public EnemyTeam enemyTeam;

    public void recycleAll()
    {
        heroTeam.recycleAll();
        enemyTeam.recycleAll();
    }

    public void copyAllySlot(HeroSlot slot)
    {
    }

    public void setAllyTeam()
    {
    }

    public void setEnemyTeam()
    {
    }
}
