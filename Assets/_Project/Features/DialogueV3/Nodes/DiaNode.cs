using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "DiaNode",
        menuName = "Dialogue Node/Dialogue",
        order = 0)
]
public class DiaNode : ScriptableObject
{
    private string type = "dia";

    public string text;

    public ScriptableObject next;
}
