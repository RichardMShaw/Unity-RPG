using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleViewer : MonoBehaviour
{
    public GameObject battleUI;

    public RawImage background;

    public GameObject heroes;

    public List<HeroSlotComponent> heroesFrontRow;

    public List<HeroSlotComponent> heroesBackRow;

    public GameObject statusEffectOverviewPrefab;

    public GameObject statusEffectOverviewInst;

    public void setBackground(Texture bg)
    {
        background.material.mainTexture = bg;
    }

    public void setHeroes(HeroTeam heroTeam)
    {
        var frontRowHeroes = heroTeam.frontRowHeroes;
        var backRowHeroes = heroTeam.backRowHeroes;
        for (int i = 0; i < 3; i++)
        {
            if (i < frontRowHeroes.Count)
            {
                heroesFrontRow[i].setHeroSlot(frontRowHeroes[i]);
            }
            else
            {
                heroesFrontRow[i].clear();
            }
            if (i < backRowHeroes.Count)
            {
                heroesBackRow[i].setHeroSlot(backRowHeroes[i]);
            }
            else
            {
                heroesBackRow[i].clear();
            }
        }
    }

    public void onBattleStart()
    {
    }

    public void showEnemyStatus(EnemySlot target)
    {
        var temp = target.temporaryStatusEffectSlots;
        var passives = target.passives;
    }
}
