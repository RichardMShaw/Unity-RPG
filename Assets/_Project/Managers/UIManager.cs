using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvas;

    public GameObject debug;

    public GameObject battle;

    private void Start()
    {
        GameEvents.events.onBattleStart += battleStart;
        GameEvents.events.onBattleEnd += battleEnd;
    }

    private void battleStart()
    {
        debug.SetActive(false);
        battle.SetActive(true);
    }

    private void battleEnd()
    {
        debug.SetActive(true);
        battle.SetActive(false);
    }
}
