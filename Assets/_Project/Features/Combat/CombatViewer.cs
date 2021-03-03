using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatViewer : ScriptableObject
{
    public GameObject statusEffectOverview;

    public void showEnemyStatus(EnemySlot target)
    {
        var temp = target.getTemporaryStatusEffects();
        var passives = target.getPassiveStatusEffects();
    }
}
