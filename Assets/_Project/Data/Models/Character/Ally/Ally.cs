using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[
    CreateAssetMenu(
        fileName = "A New Ally Character",
        menuName = "Combat/Ally",
        order = 0)
]
public class Ally : Character
{
    [Header("Visuals")]
    public Image menu;

    public Image icon;

    [Header("Skills")]
    public List<Skill> skills;

    private AllyTeam team;

    public int actionPoints;
}
