using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "SkilLDataBase",
        menuName = "Database/Skill",
        order = 0)
]
public class SkillDatabase : ScriptableObject
{
    public List<Skill> skills;
}
