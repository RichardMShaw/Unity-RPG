using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[Serializable]
public class CharacterStat
{
    public float baseValue;

    public virtual float Value
    {
        get
        {
            if (isDirty || baseValue != lastBaseValue)
            {
                lastBaseValue = baseValue;
                _value = calculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }

    protected bool isDirty = true;

    protected float _value;

    protected float lastBaseValue = float.MinValue;

    protected readonly List<StatModifier> statModifiers;

    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public CharacterStat()
    {
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    public CharacterStat(float _baseValue) :
        this()
    {
        baseValue = _baseValue;
    }

    public virtual void addModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add (mod);
        statModifiers.Sort (compareModOrder);
    }

    protected virtual int compareModOrder(StatModifier a, StatModifier b)
    {
        {
            if (a.order < b.order)
                return -1;
            else if (a.order > b.order) return 1;

            return 0;
        }
    }

    public virtual bool removeModifier(StatModifier mod)
    {
        isDirty = true;
        if (statModifiers.Remove(mod))
        {
            isDirty = true;
            return true;
        }
        return false;
    }

    public virtual bool removeAllModifiersFromSource(object source)
    {
        bool didRemove = false;
        for (int i = statModifiers.Count - 1; i > -1; i--)
        {
            StatModifier mod = statModifiers[i];
            if (mod.source == source)
            {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt (i);
            }
        }
        return didRemove;
    }

    protected virtual float calculateFinalValue()
    {
        float finalValue = baseValue;
        float sumPercentAdd = 0;
        int prevOrder = 0;

        for (int i = statModifiers.Count - 1; i > -1; i--)
        {
            StatModifier mod = statModifiers[i];
            if (mod.type == StatModType.Flat)
            {
                finalValue += mod.value;
            }
            else if (mod.type == StatModType.Percent)
            {
                if (mod.order != prevOrder)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
                sumPercentAdd += mod.value;
            }
            prevOrder = mod.order;
        }
        finalValue *= 1 + sumPercentAdd;

        return (float) Math.Round(finalValue, 4);
    }
}
