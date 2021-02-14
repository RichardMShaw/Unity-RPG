using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "GameState",
        menuName = "GameState/GameState",
        order = 0)
]
public class GameState : ScriptableObject
{
    public static GameState gameState;

    public State state;

    public FlagCollection flags;

    private void OnEnable()
    {
        gameState = this;
        flags = new FlagCollection(state.flags);
    }

    public void load()
    {
        flags.load(state.flags);
    }
}

[Serializable]
public struct State
{
    public List<Flag> flags;

    public Inventory playerInv;
}
