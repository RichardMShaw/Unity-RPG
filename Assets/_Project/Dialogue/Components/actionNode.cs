using System;
using UnityEngine;

public class actionNode : MonoBehaviour
{
    [Serializable]
    public struct ActionExpression
    {
        public string variable;

        public string expression;

        public string type;

        public string val;
    }

    public ActionExpression[] actions;

    public GameObject next;
}
