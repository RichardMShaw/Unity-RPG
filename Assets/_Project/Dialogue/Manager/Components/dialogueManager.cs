using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public GameObject dialogueOverlay;

    public Transform choiceList;

    public Button choicePrefab;

    private GameObject currentNode;

    public void startDialogue(startNode start)
    {
        Color color = dialogueOverlay.GetComponent<Image>().color;
        color.a = 1f;
        dialogueOverlay.GetComponent<Image>().color = color;
        this.onNodeSelect(start.start);
    }

    private void KillAllChildren(UnityEngine.Transform parent)
    {
        UnityEngine.Assertions.Assert.IsNotNull (parent);
        for (
            int childIndex = parent.childCount - 1;
            childIndex >= 0;
            childIndex--
        )
        {
            UnityEngine.Object.Destroy(parent.GetChild(childIndex).gameObject);
        }
    }

    private void parseDialogue()
    {
        dialogueText.SetText(currentNode.GetComponent<dialogueNode>().text);
        var nextNode = currentNode.GetComponent<dialogueNode>().next;
        this.KillAllChildren(choiceList);
        var choice = Instantiate(choicePrefab, choiceList);
        choice.GetComponentInChildren<TextMeshProUGUI>().SetText("Next");
        choice
            .onClick
            .AddListener(delegate ()
            {
                onNodeSelect (nextNode);
            });
    }

    private void parseChoice()
    {
        this.KillAllChildren(choiceList);
        var choices = currentNode.GetComponent<choiceNode>().choices;
        var length = choices.Length;
        for (var i = 0; i < length; i++)
        {
            var choice = Instantiate(choicePrefab, choiceList);
            choice.GetComponentInChildren<TextMeshProUGUI>().SetText(choices[i].text);
            choice
                .onClick
                .AddListener(delegate ()
                {
                    onNodeSelect(choices[i].next);
                });
        }
    }

    private void parseAction()
    {
        var action = currentNode.GetComponent<actionNode>();
        action.onAction.Invoke();
        this.onNodeSelect(action.next);
    }

    private void onNodeSelect(GameObject node)
    {
        currentNode = node;
        Console.WriteLine("Test");
        this.nextNode();
    }

    public void nextNode()
    {
        typeNode type = currentNode.GetComponent<typeNode>();
        switch (type.type)
        {
            case "dialogue":
                this.parseDialogue();
                break;
            case "choice":
                this.parseChoice();
                break;
            case "action":
                this.parseAction();
                break;
        }
    }

    public void endDialogue()
    {
        Color color = dialogueOverlay.GetComponent<SpriteRenderer>().color;
        color.a = 0f;
        dialogueOverlay.GetComponent<SpriteRenderer>().color = color;
    }
}
