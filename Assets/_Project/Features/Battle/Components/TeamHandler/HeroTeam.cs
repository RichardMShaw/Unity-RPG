using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroTeam
{
    public Queue<HeroSlot> reservedHeroSlots;

    public List<HeroSlot> frontRowHeroes;

    public List<HeroSlot> backRowHeroes;

    public void recycleAll()
    {
        for (int i = frontRowHeroes.Count; i > -1; i--)
        {
            reservedHeroSlots.Enqueue(frontRowHeroes[i]);
        }
        frontRowHeroes.Clear();
        for (int i = backRowHeroes.Count; i > -1; i--)
        {
            reservedHeroSlots.Enqueue(backRowHeroes[i]);
        }
        backRowHeroes.Clear();
    }

    public HeroSlot addHeroToFrontRow(Hero hero)
    {
        if (reservedHeroSlots.Count < 1)
        {
            return null;
        }
        HeroSlot newHero;
        if (frontRowHeroes.Count > 2)
        {
            if (backRowHeroes.Count > 2)
            {
                return null;
            }
            newHero = reservedHeroSlots.Dequeue();
            newHero.setTemplate (hero);
            backRowHeroes.Add (newHero);

            return newHero;
        }
        newHero = reservedHeroSlots.Dequeue();
        newHero.setTemplate (hero);
        frontRowHeroes.Add (newHero);

        return newHero;
    }

    public HeroSlot addHeroToBackRow(Hero hero)
    {
        if (reservedHeroSlots.Count < 1)
        {
            return null;
        }

        HeroSlot newHero;
        if (backRowHeroes.Count > 2)
        {
            if (frontRowHeroes.Count > 2)
            {
                return null;
            }
            newHero = reservedHeroSlots.Dequeue();
            newHero.setTemplate (hero);
            frontRowHeroes.Add (newHero);

            return newHero;
        }
        newHero = reservedHeroSlots.Dequeue();
        newHero.setTemplate (hero);
        frontRowHeroes.Add (newHero);

        return newHero;
    }

    public bool recycleHeroSlot(HeroSlot slot)
    {
        if (!frontRowHeroes.Remove(slot))
        {
            if (!backRowHeroes.Remove(slot))
            {
                return false;
            }
        }
        reservedHeroSlots.Enqueue (slot);
        return true;
    }
}
