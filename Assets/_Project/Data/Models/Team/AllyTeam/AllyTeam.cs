using System;
using System.Collections.Generic;
using UnityEngine;

public class AllyTeam : Team
{
    public List<Ally> team
    {
        get
        {
            List<Ally> teammates = new List<Ally>();
            int len = frontRow.Count;
            for (int i = 0; i < len; i++)
            {
                teammates.Add(frontRow[i]);
            }
            len = backRow.Count;
            for (int i = 0; i < len; i++)
            {
                teammates.Add(backRow[i]);
            }
            return teammates;
        }
    }

    public List<Ally> frontRow;

    public List<Ally> backRow;

    public void addFrontRow(Ally ally)
    {
        ally.row = CharacterRow.front;
    }

    public void addBackRow(Ally ally)
    {
        ally.row = CharacterRow.back;
    }

    public void combatInit()
    {
        int len = team.Count;
    }
}
