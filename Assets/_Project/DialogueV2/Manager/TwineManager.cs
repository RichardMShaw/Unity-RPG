// using System;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// public class TwineManager : MonoBehaviour
// {
//     public TextMeshProUGUI dialogueText;

//     public GameObject dialogueOverlay;

//     public Transform choiceList;

//     public Button choicePrefab;

//     //public FlagState flagState;

//     public TwineSituation twine;

//     public string nodeKey;

//     public void startDialogue(TextAsset story)
//     {
//         dialogueOverlay.SetActive(true);
//         twine.parseTwineStory (story);
//         onNodeSelect(twine.start);
//     }

//     private void KillAllChildren(UnityEngine.Transform parent)
//     {
//         UnityEngine.Assertions.Assert.IsNotNull (parent);
//         for (
//             int childIndex = parent.childCount - 1;
//             childIndex >= 0;
//             childIndex--
//         )
//         {
//             UnityEngine.Object.Destroy(parent.GetChild(childIndex).gameObject);
//         }
//     }

//     private void parseDialogue()
//     {
//         var node = twine.getDialogueNode(nodeKey);
//         dialogueText.SetText(node.text);
//         dialogueText.transform.position = new Vector3(0,300,0);
//         var choices = node.choices;
//         this.KillAllChildren(choiceList);
//         int len = choices.Length;
//         for (int i = 0; i < len; i++)
//         {
//             var choice = Instantiate(choicePrefab, choiceList);
//             var next = choices[i].next;
//             choice
//                 .GetComponentInChildren<TextMeshProUGUI>()
//                 .SetText(choices[i].text);
//             choice
//                 .onClick
//                 .AddListener(delegate ()
//                 {
//                     onNodeSelect(next);
//                 });
//         }
//     }

//     private void parseAction()
//     {
//         var node = twine.getActionNode(nodeKey);
//         var actions = node.actions;
//         int len = actions.Length;
//         for (int i = 0; i < len; i++)
//         {
//             string script = actions[i].script;
//             string[] args = actions[i].args;
//             switch (script)
//             {
//                 case "change":
//                     if (args[1][0] == '$')
//                     {
//                         int val = flagState.getVal(args[1].Substring(1));
//                         flagState.changeVal(args[0].Substring(1), val);
//                     }
//                     else
//                     {
//                         int val = Int32.Parse(args[1]);
//                         flagState.changeVal(args[0].Substring(1), val);
//                     }
//                     break;
//                 case "set":
//                     if (args[1][0] == '$')
//                     {
//                         int val = flagState.getVal(args[1].Substring(1));
//                         flagState.setVal(args[0].Substring(1), val);
//                     }
//                     else
//                     {
//                         int val = Int32.Parse(args[1]);
//                         flagState.setVal(args[0].Substring(1), val);
//                     }
//                     break;
//             }
//         }
//         onNodeSelect(node.next);
//     }

//     private void parseCondition()
//     {
//         var node = twine.getConditionNode(nodeKey);
//         var conditions = node.conditions;
//         int len = conditions.Count;
//         for (int i = 0; i < len; i++)
//         {
//             var statements = conditions[i].statements;
//             bool isTrue = true;
//             int lenState = statements.Count;
//             for (int j = 0; j < lenState; j++)
//             {
//                 string script = statements[i].script;
//                 string[] args = statements[i].args;
//                 switch (script)
//                 {
//                     case "compare":
//                         if (args[1][0] == '$')
//                         {
//                             int val = flagState.getVal(args[2].Substring(1));
//                             if (
//                                 !flagState
//                                     .compareTwineFlagtoVal(args[0].Substring(1),
//                                     args[1],
//                                     val)
//                             )
//                             {
//                                 isTrue = false;
//                                 j = lenState;
//                             }
//                         }
//                         else
//                         {
//                             int val = Int32.Parse(args[2]);
//                             if (
//                                 !flagState
//                                     .compareTwineFlagtoVal(args[0].Substring(1),
//                                     args[1],
//                                     val)
//                             )
//                             {
//                                 isTrue = false;
//                                 j = lenState;
//                             }
//                         }
//                         break;
//                 }
//             }
//             if (isTrue)
//             {
//                 onNodeSelect(conditions[i].next);
//                 return;
//             }
//         }
//         onNodeSelect(node.defaultNext);
//     }

//     private void onNodeSelect(string next)
//     {
//         nodeKey = next;
//         nextNode();
//     }

//     public void nextNode()
//     {
//         if (nodeKey == "")
//         {
//             endDialogue();
//             return;
//         }
//         var node = twine.getNode(nodeKey);
//         switch (node.type)
//         {
//             case "dialogue":
//                 parseDialogue();
//                 break;
//             case "action":
//                 parseAction();
//                 break;
//             case "condition":
//                 parseCondition();
//                 break;
//             default:
//                 endDialogue();
//                 break;
//         }
//     }

//     public void endDialogue()
//     {
//         dialogueOverlay.SetActive(false);
//     }

//     private void Start()
//     {
//         dialogueOverlay.SetActive(false);
//     }
// }
