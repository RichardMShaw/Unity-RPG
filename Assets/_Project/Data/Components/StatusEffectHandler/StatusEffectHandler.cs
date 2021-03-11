using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatusEffectHandler
{
    [SerializeField]
    public List<TempStatusEffectSlot> temp;

    [SerializeField]
    public List<StatusEffectSlot> passives;

    public CharacterEvents events;

    public CharacterEvents getEvents()
    {
        return events;
    }
}
