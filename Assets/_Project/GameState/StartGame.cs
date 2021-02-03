using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameState gameState;

    void Start()
    {
        gameState.start();
    }
}
