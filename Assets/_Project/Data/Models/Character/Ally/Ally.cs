using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Ally", menuName = "Database/Ally", order = 0)]
public class Ally : Character
{
    [Header("Visuals")]
    public Image menu;

    public Image icon;

    [Header("Skills")]
    [SerializeField]
    public List<SkillSlot> skills;
}
