using System.Collections.Generic;

public class PlayerSkillSlot
{
    public Skill skill;

    //How many times the player can use the skill. Less than 0 means infinite uses.
    public int uses;

    //Which status effects are preventing the player from using the skill.
    public List<StatusEffect> restrictors;
}
