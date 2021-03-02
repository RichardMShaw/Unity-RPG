using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatViewer : ScriptableObject
{

  public GameObject statusEffects;
  public void showEnemyStatus(Enemy target){
    var temp = target.getTemporaryStatusEffects();
    var passives = target.getPassiveStatusEffects();




  }
}