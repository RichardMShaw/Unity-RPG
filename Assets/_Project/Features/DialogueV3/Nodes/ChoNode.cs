using System;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "ChoNode",
        menuName = "Dialogue Node/Choices",
        order = 0)
]
public class ChoNode : ScriptableObject
{
    private string type = "cho";

    [Serializable]
    public struct Choice
    {
        public string text;

        public ScriptableObject next;
    }

    public Choice[] choices;
}
