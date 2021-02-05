using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents events;

    private void Awake()
    {
        events = this;
    }

    public event Action onTurnEnd;

    public void turnEnd()
    {
        if (onTurnEnd != null)
        {
            onTurnEnd();
        }
    }
}
