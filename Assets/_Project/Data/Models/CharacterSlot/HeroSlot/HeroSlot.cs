using System.Collections.Generic;
using UnityEngine;

public class HeroSlot : CharacterSlot
{
    public HeroSlot original;

    public Hero template;

    public int actionPoint;

    public override List<StatusEffectSlot> passives
    {
        get
        {
            return template.passives;
        }
    }

    public void saveToOriginal()
    {
        if (original == null)
        {
            Debug.Log("HeroSlot.cs: There is no original to copy all of the clone's values into.");
            return;
        }

        original.health = health;

        original.stats.removeAllModifiers();

        original.events.clear();

        var passiveList = passives;
        int len = passives.Count;
        for (int i = 0; i < len; i++)
        {
            original.events += passiveList[i].events;
            passiveList[i].onAdd(original);
        }

        original.temporaryStatusEffectSlots.Clear();
        var tempStatusSlots = temporaryStatusEffectSlots;
        len = tempStatusSlots.Count;
        for (int i = 0; i < len; i++)
        {
            var tempStatusClone = tempStatusSlots[i].createClone();
            original.temporaryStatusEffectSlots.Add (tempStatusClone);
            original.events += tempStatusClone.events;
            tempStatusClone.onAdd (original);
        }
    }

    public void clone(HeroSlot _original)
    {
        original = _original;

        template = original.template;

        label = original.label;

        health = original.health;

        stats.removeAllModifiers();
        stats.copyBaseStats(template.baseStats);

        events.clear();
        var passiveList = passives;
        int len = passives.Count;
        for (int i = 0; i < len; i++)
        {
            events += passiveList[i].events;
            passiveList[i].onAdd(this);
        }

        temporaryStatusEffectSlots.Clear();
        var tempStatusSlots = original.temporaryStatusEffectSlots;
        len = tempStatusSlots.Count;
        for (int i = 0; i < len; i++)
        {
            var tempStatusClone = tempStatusSlots[i].createClone();
            temporaryStatusEffectSlots.Add (tempStatusClone);
            events += tempStatusClone.events;
            tempStatusClone.onAdd(this);
        }
    }

    public void setTemplate(Hero _template)
    {
        template = _template;
    }
}
