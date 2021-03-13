using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroSlotComponent : MonoBehaviour
{
    private BattleController battleController;
    public HeroSlot heroSlot;

    public TextMeshProUGUI label;

    public int health;

    public float maxHealth;

    public RawImage healthBar;

    public TextMeshProUGUI healthText;

    public int special;

    public float maxSpecial;

    public RawImage specialBar;

    public TextMeshProUGUI specialText;

    public List<StatusEffect> statusEffects;

    public GameObject statusEffectList;

    public void clicked()
    {

    }

    public void setHeroSlot(HeroSlot _heroSlot)
    {
        heroSlot = _heroSlot;
        loadAllFromHero();
    }

    public void loadHealthFromHero()
    {
        health = heroSlot.health;
        maxHealth = heroSlot.stats.maxHealth.Value;
        float scale = health / maxHealth;
        if (scale > 1.0f)
        {
            scale = 1.0f;
        }
        healthBar.rectTransform.localScale = new Vector3(scale, 1, 1);
        healthText.text = health + " / " + maxHealth;
    }

    public void loadSpecialFromHero()
    {
    }

    public void loadStatusEffectsFromHero()
    {
        statusEffects.Clear();
        var tempSlots = heroSlot.temporayStatusEffectSlots;
        int len = tempSlots.Count;
        int i = 0;
        for (; i < len; i++)
        {
            statusEffects.Add(tempSlots[i].statusEffect);
        }
        i = 0;
        foreach (Transform child in statusEffectList.transform)
        {
            if (i < len)
            {
                var raw = child.gameObject.GetComponent<RawImage>();
                if (raw != null)
                {
                    raw.material.mainTexture = statusEffects[i].icon;
                }
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void loadAllFromHero()
    {
        if (heroSlot == null)
        {
            return;
        }
        label.text = heroSlot.label;
        loadHealthFromHero();
        loadStatusEffectsFromHero();
    }

    public void clear()
    {
        heroSlot = null;
        health = 0;
        maxHealth = 0f;
        healthText.text = "";
        healthBar.rectTransform.localScale = new Vector3(0, 1, 1);
        special = 0;
        maxSpecial = 0f;
        specialText.text = "";
        specialBar.rectTransform.localScale = new Vector3(0, 1, 1);

        statusEffects.Clear();
        foreach (Transform child in statusEffectList.transform)
        {
            child.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
}
