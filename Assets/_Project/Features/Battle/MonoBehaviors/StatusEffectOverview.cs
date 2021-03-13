using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectOverview : MonoBehaviour
{
    public GameObject statusEffectSlot;

    public GameObject temp;

    public GameObject passives;

    public void setEnemy(EnemySlot enemy)
    {
    }

    public void setHero(HeroSlot ally)
    {
    }

    private void setStatusEffectSlots(CharacterSlot character)
    {
        var tempList = character.temporayStatusEffectSlots;
        var passivesList = character.passives;

        foreach (Transform child in temp.transform)
        {
            Destroy(child.gameObject);
        }
        int len = tempList.Count;
        for (int i = 0; i < len; i++)
        {
            GameObject slotObj = Instantiate(statusEffectSlot);
            var slot =
                statusEffectSlot.GetComponent<StatusEffectSlotComponent>();
            slot.setStatusEffect(tempList[i]);
        }
    }

    void Update()
    {
    }
}
