using System;
using UnityEngine;

public enum StatusEffectType
{
    None,
    Buff,
    Debuff,
    Invisible
}

[Serializable]
public class StatusEffect : ScriptableObject
{
    public string id;

    public StatusEffectType type;

    [TextArea(3, 20)]
    public string description;

    public CharacterEvents events;
}
