using System;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "allyGroup",
        menuName = "Combat/Group/Enemy",
        order = 0)
]
public class EnemyGroup : ScriptableObject
{
    List<EnemySlot> frontRow;

    List<EnemySlot> backRow;
}
