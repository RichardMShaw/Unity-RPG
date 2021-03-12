using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroTeam
{
    public Queue<HeroSlot> reservedHeroSlots;

    public List<HeroSlot> frontRowAllies;

    public List<HeroSlot> backRowAllies;

    public void recycleAll()
    {
        for (int i = frontRowAllies.Count; i > -1; i--)
        {
            reservedHeroSlots.Enqueue(frontRowAllies[i]);
        }
        frontRowAllies.Clear();
        for (int i = backRowAllies.Count; i > -1; i--)
        {
            reservedHeroSlots.Enqueue(backRowAllies[i]);
        }
        backRowAllies.Clear();
    }

    public HeroSlot addHeroToFrontRow(Hero hero)
    {
        if (reservedHeroSlots.Count < 1)
        {
            return null;
        }
        HeroSlot newHero;
        if (frontRowAllies.Count > 2)
        {
            if (backRowAllies.Count > 2)
            {
                return null;
            }
            newHero = reservedHeroSlots.Dequeue();
            newHero.setTemplate (hero);
            backRowAllies.Add (newHero);

            return newHero;
        }
        newHero = reservedHeroSlots.Dequeue();
        newHero.setTemplate (hero);
        frontRowAllies.Add (newHero);

        return newHero;
    }

    public HeroSlot addHeroToBackRow(Hero hero)
    {
        if (reservedHeroSlots.Count < 1)
        {
            return null;
        }

        HeroSlot newHero;
        if (backRowAllies.Count > 2)
        {
            if (frontRowAllies.Count > 2)
            {
                return null;
            }
            newHero = reservedHeroSlots.Dequeue();
            newHero.setTemplate (hero);
            frontRowAllies.Add (newHero);

            return newHero;
        }
        newHero = reservedHeroSlots.Dequeue();
        newHero.setTemplate (hero);
        frontRowAllies.Add (newHero);

        return newHero;
    }

    public bool recycleHeroSlot(HeroSlot slot)
    {
        if (!frontRowAllies.Remove(slot))
        {
            if (!backRowAllies.Remove(slot))
            {
                return false;
            }
        }
        reservedHeroSlots.Enqueue (slot);
        return true;
    }
}
