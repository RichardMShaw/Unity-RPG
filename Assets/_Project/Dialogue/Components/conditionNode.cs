using System;
using UnityEngine;

public class conditionNode : MonoBehaviour
{
    [Serializable]
    public struct Condition
    {
        public string variable;

        public string expression;

        public string type;

        public string val;
    }

    [Serializable]
    public struct Result
    {
        public Condition[] conditions;

        public GameObject next;
    }

    public Result[] results;
}
