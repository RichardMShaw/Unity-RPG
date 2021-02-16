using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "A Player Character",
        menuName = "Combat/Player Character",
        order = 0)
]
public class Player : Character
{
    [Header("Visuals")]
    public Sprite menu;

    public Sprite icon;

    [Header("Skills")]
    public List<Skill> skills;
}
