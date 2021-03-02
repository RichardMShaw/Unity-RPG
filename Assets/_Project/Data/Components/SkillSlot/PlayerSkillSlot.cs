using System.Collections.Generic;

public class PlayerSkillSlot
{
    //Reference to skill
    public Skill skill;

    //How many times the player can use the skill. Less than 0 means infinite uses.
    public int uses;
}
