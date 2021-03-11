using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatViewer : ScriptableObject
{
    public GameObject statusEffectOverviewPrefab;

    public GameObject statusEffectOverviewInst;

    public void onBattleStart(Field field){
        
    }

    public void showEnemyStatus(EnemySlot target)
    {
        var temp = target.getTemporaryStatusEffects();
        var passives = target.getPassiveStatusEffects();
    }
}
