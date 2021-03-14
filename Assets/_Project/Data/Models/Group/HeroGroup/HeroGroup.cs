using System;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "New Hero Group",
        menuName = "Combat/Group/Hero",
        order = 0)
]
public class HeroGroup : ScriptableObject
{

    public List<HeroSlot> frontRow;

    public List<HeroSlot> backRow;
}
