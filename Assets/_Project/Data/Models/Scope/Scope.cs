using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scope", menuName = "Combat/Scope", order = 0)]
public class Scope : ScriptableObject
{
    public bool isTargetValid(CharacterSlot caster, CharacterSlot target)
    {
        return false;
    }

    public List<CharacterSlot> getValidTargets(CharacterSlot caster)
    {
        return null;
    }
}
