using System;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "allyGroup",
        menuName = "Combat/Group/Ally",
        order = 0)
]
public class AllyGroup : ScriptableObject
{
    List<AllySlot> frontRow;

    List<AllySlot> backRow;
}
