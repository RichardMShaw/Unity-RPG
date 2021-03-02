using System;
using UnityEngine;

public class choiceNode : MonoBehaviour
{
    [Serializable]
    public struct Choice
    {
      public string text;
      public GameObject next;
    }

    public Choice[] choices;
}
