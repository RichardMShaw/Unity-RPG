using System;
using UnityEngine;
using UnityEngine.Events;

[
    CreateAssetMenu(
        fileName = "ConNode",
        menuName = "Dialogue Node/Conditions",
        order = 0)
]
public class ConNode : ScriptableObject
{
    [Serializable]
    public class Condition : UnityEvent<string, string, string, string> { }

    private string type = "con";

    [Serializable]
    public struct Statement
    {
        public Condition onCondition;

        public string[] args;

        public ScriptableObject next;
    }

    public Statement[] choices;

    public ScriptableObject defaultNext;
}
