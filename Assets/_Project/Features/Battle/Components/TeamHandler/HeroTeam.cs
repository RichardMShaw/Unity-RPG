using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroTeam
{
    public List<HeroSlot> originalHeroSlots;

    public List<HeroSlot> clonedHeroSlots;

    public Queue<HeroSlot> reservedHeroSlots;

    public List<HeroSlot> reservedClonedHeroSlots;

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
        for (int i = reservedClonedHeroSlots.Count; i > -1; i--)
        {
            reservedHeroSlots.Enqueue(reservedClonedHeroSlots[i]);
        }
        backRowHeroes.Clear();
    }

    public void setHeroGroup(HeroGroup heroGroup)
    {
        recycleAll();
        var front = heroGroup.frontRow;
        int len = front.Count;
        for (int i = 0; i < len; i++)
        {
            var newHero = reservedHeroSlots.Dequeue();
            newHero.clone(front[i]);
        }
        var back = heroGroup.backRow;
        for (int i = 0; i < len; i++)
        {
            var newHero = reservedHeroSlots.Dequeue();
            newHero.clone(back[i]);
        }
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
        reservedClonedHeroSlots.Add (slot);
        return true;
    }
}
