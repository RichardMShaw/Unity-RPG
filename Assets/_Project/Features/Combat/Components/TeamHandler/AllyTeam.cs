using System;
using System.Collections.Generic;
using UnityEngine;

public class AllyTeam
{
    public Queue<AllySlot> reservedAllySlots;

    public List<AllySlot> frontRowAllies;

    public List<AllySlot> backRowAllies;

    public void recycleAll()
    {
        for (int i = frontRowAllies.Count; i > -1; i--)
        {
            reservedAllySlots.Enqueue(frontRowAllies[i]);
        }
        frontRowAllies.Clear();
        for (int i = backRowAllies.Count; i > -1; i--)
        {
            reservedAllySlots.Enqueue(backRowAllies[i]);
        }
        backRowAllies.Clear();
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
            newAlly = reservedAllySlots.Dequeue();
            newAlly.setTemplate (ally);
            backRowAllies.Add (newAlly);

            return newAlly;
        }
        newAlly = reservedAllySlots.Dequeue();
        newAlly.setTemplate (ally);
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
            newAlly = reservedAllySlots.Dequeue();
            newAlly.setTemplate (ally);
            frontRowAllies.Add (newAlly);

            return newAlly;
        }
        newAlly = reservedAllySlots.Dequeue();
        newAlly.setTemplate (ally);
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
        reservedAllySlots.Enqueue (slot);
        return true;
    }
}
