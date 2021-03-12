using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillSlot
{
    [SerializeField]
    //Reference to skill
    public Skill skill;

    //How many times the player can use the skill. Less than 0 means infinite uses.
    public int uses;
}
