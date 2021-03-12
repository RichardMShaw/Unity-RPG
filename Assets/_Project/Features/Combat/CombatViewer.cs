using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatViewer : ScriptableObject
{
    public GameObject statusEffectOverviewPrefab;

    public GameObject statusEffectOverviewInst;

    public void setBackground(Image bg){

    }

    public void onBattleStart()
    {
    }

    public void showEnemyStatus(EnemySlot target)
    {
        var temp = target.temporaySlots;
        var passives = target.passiveSlots;
    }
}
