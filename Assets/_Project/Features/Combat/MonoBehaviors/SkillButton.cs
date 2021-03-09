using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public CombatController combatController;

    public Skill skill;

    public TextMeshProUGUI text;

    public void setSkill(Skill _skill)
    {
        skill = _skill;
        text.SetText(skill.label);
    }

    public void onClicked()
    {
        combatController.onSkillClicked (skill);
    }
}
