using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeam : Team
{
    public List<Player> team
    {
        get
        {
            List<Player> teammates = new List<Player>();
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

    public List<Player> frontRow;

    public List<Player> backRow;

    public Field field;

    public void addFrontRow(Player player)
    {
        player.row = CharacterRow.front;
    }

    public void addBackRow(Player player)
    {
        player.row = CharacterRow.back;
    }

    public void combatInit()
    {
        int len = team.Count;
    }
}
