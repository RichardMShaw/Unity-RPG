using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public FlagState flagState;
    void Start()
    {
        flagState.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
