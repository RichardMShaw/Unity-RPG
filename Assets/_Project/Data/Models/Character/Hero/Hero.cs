using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Hero", menuName = "Database/Hero", order = 0)]
public class Hero : Character
{
    [Header("Visuals")]
    public Image menu;

    public Image icon;

    [Header("Skills")]
    [SerializeField]
    public List<SkillSlot> skills;
}
