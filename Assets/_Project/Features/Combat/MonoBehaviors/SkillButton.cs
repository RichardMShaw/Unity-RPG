using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Skill skill;

    public TextMeshProUGUI text;

    public void setSkill(Skill _skill)
    {
        skill = _skill;
        text.SetText(skill.label);
    }

    public void skillSelected(){


    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
