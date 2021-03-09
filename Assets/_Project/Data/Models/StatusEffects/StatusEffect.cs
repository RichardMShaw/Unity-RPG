using System;
using UnityEngine;
using UnityEngine.UI;

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

    public Sprite icon;

    [TextArea(3, 10)]
    public string description;

    public CharacterEvents events;

    public string print()
    {
        return description;
    }
}
