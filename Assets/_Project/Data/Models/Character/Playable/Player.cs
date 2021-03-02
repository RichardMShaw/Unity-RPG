using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[
    CreateAssetMenu(
        fileName = "A Player Character",
        menuName = "Combat/Player Character",
        order = 0)
]
public class Player : Character
{

    [Header("Visuals")]
    public Image menu;

    public Image icon;

    [Header("Skills")]
    public List<Skill> skills;

    private PlayerTeam team;
}
