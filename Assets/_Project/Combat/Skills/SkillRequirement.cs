using UnityEngine;

[
    CreateAssetMenu(
        fileName = "SkillRequirement",
        menuName = "Combat/Skill/Requirement",
        order = 0)
]
public class SkillRequirement : ScriptableObject
{
    public Sprite icon;

    public string description;
}
