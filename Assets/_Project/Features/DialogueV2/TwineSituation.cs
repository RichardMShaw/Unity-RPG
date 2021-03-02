using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "TwineSituation",
        menuName = "Story/TwineSituation",
        order = 0)
]
public class TwineSituation : ScriptableObject
{
    public string start;

    [Serializable]
    public class Node
    {
        public string type;

        public string title;

        public Node(string nodeTitle, string nodeType)
        {
            title = nodeTitle;
            type = nodeType;
        }
    }

    [Serializable]
    public struct Choice
    {
        public string text;

        public string next;

        public Choice(string choiceText, string choiceNext)
        {
            text = choiceText;
            next = choiceNext;
        }
    }

    [Serializable]
    public class DialogueNode : Node
    {
        public string text;

        public Choice[] choices;

        public DialogueNode(
            string type,
            string title,
            string nodeText,
            Choice[] nodeChoices
        ) :
            base(type, title)
        {
            text = nodeText;
            choices = nodeChoices;
        }
    }

    [Serializable]
    public struct Statement
    {
        public string script;

        public string[] args;

        public Statement(string statementScript, string[] statementArgs)
        {
            script = statementScript;
            args = statementArgs;
        }
    }

    [Serializable]
    public class ActionNode : Node
    {
        public Statement[] actions;

        public string next;

        public ActionNode(
            string type,
            string title,
            Statement[] nodeStatements,
            string nodeNext
        ) :
            base(type, title)
        {
            actions = nodeStatements;
            next = nodeNext;
        }
    }

    [Serializable]
    public struct Condition
    {
        public List<Statement> statements;

        public string next;

        public Condition(
            List<Statement> conditionStatements,
            string conditionNext
        )
        {
            statements = conditionStatements;
            next = conditionNext;
        }
    }

    [Serializable]
    public class ConditionNode : Node
    {
        public List<Condition> conditions;

        public string defaultNext;

        public ConditionNode(
            string type,
            string title,
            List<Condition> nodeConditions,
            string nodeNext
        ) :
            base(type, title)
        {
            conditions = nodeConditions;
            defaultNext = nodeNext;
        }
    }

    public List<Node> nodes = new List<Node>();

    private Dictionary<string, int> nodeIndexes = new Dictionary<string, int>();

    public Node getNode(string key)
    {
        return nodes[nodeIndexes[key]];
    }

    public DialogueNode getDialogueNode(string key)
    {
        return (DialogueNode) nodes[nodeIndexes[key]];
    }

    public ActionNode getActionNode(string key)
    {
        return (ActionNode) nodes[nodeIndexes[key]];
    }

    public ConditionNode getConditionNode(string key)
    {
        return (ConditionNode) nodes[nodeIndexes[key]];
    }

    private ConditionNode parseCondition(string nodeData, string title)
    {
        List<string> lines =
            new List<string>(nodeData
                    .Split(new string[] { "\r\n" }, StringSplitOptions.None));

        List<Statement> statements = new List<Statement>();
        List<Condition> conditions = new List<Condition>();
        string defaultNext = "";

        int len = lines.Count;
        for (int i = 0; i < len; i++)
        {
            string line = lines[i];
            string[] words = line.Split(' ');
            switch (words[0])
            {
                case "CONDITION":
                    if (words.Length > 4)
                    {
                        int wordsLen = words.Length;
                        for (int j = 4; j < wordsLen; j++)
                        {
                            words[3] += words[j];
                        }
                    }
                    string[] args = { words[1], words[2], words[3] };
                    statements.Add(new Statement("compare", args));
                    break;
                case "NEXT":
                    string next = line.Substring(line.IndexOf("[[") + 2);
                    next = next.Substring(0, next.Length - 2);
                    conditions.Add(new Condition(statements, next));
                    statements = new List<Statement>();
                    break;
                case "DEFAULT":
                    defaultNext = line.Substring(line.IndexOf("[[") + 2);
                    defaultNext =
                        defaultNext.Substring(0, defaultNext.Length - 2);
                    break;
            }
        }

        return new ConditionNode(title, "condition", conditions, defaultNext);
    }

    private ActionNode parseAction(string nodeData, string title)
    {
        int nextStart = nodeData.IndexOf("[[");
        string next = "";
        string action = "";
        if (nextStart > -1)
        {
            next = nodeData.Substring(nextStart + 2).Trim();
            next = next.Substring(0, next.Length - 2);
            action = nodeData.Substring(nodeData.IndexOf("\r\n"));
            action = action.Substring(0, action.Length - next.Length + 4);
        }
        else
        {
            action = nodeData.Substring(nodeData.IndexOf("\r\n"));
        }
        List<string> statementLines =
            new List<string>(action
                    .Split(new string[] { "\r\n" }, StringSplitOptions.None));
        Statement[] statements = new Statement[statementLines.Count];
        int len = statementLines.Count;
        for (int i = 0; i < len; i++)
        {
            string[] line = statementLines[i].Split(' ');
            statements[i].script = line[0];
            statements[i].args = new string[line.Length - 1];

            int lineLen = line.Length;
            for (int j = 1; j < lineLen; j++)
            {
                statements[i].args[j - 1] = line[j];
            }
        }
        return new ActionNode(title, "action", statements, next);
    }

    private DialogueNode parseDialogue(string nodeData, string title)
    {
        int choiceStart = nodeData.IndexOf("[[");
        string text = "";
        if (choiceStart < 0)
        {
            text = nodeData.Substring(nodeData.IndexOf("\r\n"));
            Choice[] choice = new Choice[1];
            choice[0] = new Choice("Next", "");

            return new DialogueNode(title, "dialogue", text.Trim(), choice);
        }

        text = nodeData.Substring(nodeData.IndexOf("\r\n"));
        text = text.Substring(0, text.IndexOf("[["));
        text = text.Substring(0, text.LastIndexOf("\r\n"));

        string choiceData =
            nodeData.Substring(nodeData.IndexOf("\r\n") + text.Length);
        List<string> choiceLines =
            new List<string>(choiceData
                    .Split(new string[] { "\r\n" }, StringSplitOptions.None));
        int len = choiceLines.Count;
        for (int i = 0; i < len; i++)
        {
            string line = choiceLines[i];
            if (line.IndexOf("[[") < 0)
            {
                choiceLines.RemoveAt (i);
                i--;
                len--;
            }
        }

        Choice[] choices = new Choice[choiceLines.Count];
        for (int i = 0; i < len; i++)
        {
            string line = choiceLines[i];
            string choiceText = line.Substring(0, line.IndexOf("[["));
            string choiceNext = line.Substring(choiceText.Length + 2);
            choiceNext = choiceNext.Substring(0, choiceNext.Length - 2);

            choices[i].text = choiceText.Trim();
            if (choices[i].text == "")
            {
                choices[i].text = "Next";
            }
            choices[i].next = choiceNext.Trim();
        }
        return new DialogueNode(title, "dialogue", text.Trim(), choices);
    }

    public void parseTwineStory(TextAsset story)
    {
        nodes.Clear();
        nodeIndexes.Clear();
        string text = story.text;
        string[] data =
            text.Split(new string[] { "::" }, StringSplitOptions.None);
        int len = data.Length;
        for (int i = 4; i < len; i++)
        {
            string nodeData = data[i];
            string nodeHeader = nodeData.Substring(0,nodeData.IndexOf("\r\n"));
            int titleEnd = nodeHeader.IndexOf("[");
            string title = "";
            List<string> tag;
            if (titleEnd < 0)
            {
                title = nodeData.Substring(0,nodeData.IndexOf("\r\n")).Trim();
                tag = new List<string>();
                tag.Add("dialogue");
            }
            else
            {
                title = nodeData.Substring(0, titleEnd).Trim();
                string tagLine =
                    nodeData
                        .Substring(titleEnd + 1,
                        (nodeData.IndexOf("\r\n") - titleEnd) - 2)
                        .ToLower();
                tag =
                    new List<string>(tagLine
                            .Split(new string[] { " " },
                            StringSplitOptions.None));
            }

            if (tag.Contains("dialogue"))
            {
                nodes.Add(parseDialogue(nodeData, title));
            }
            else if (tag.Contains("action"))
            {
                nodes.Add(parseAction(nodeData, title));
            }
            else if (tag.Contains("condition"))
            {
                nodes.Add(parseCondition(nodeData, title));
            }
            else
            {
                nodes.Add(parseDialogue(nodeData, title));
            }
            if (tag.Contains("start"))
            {
                start = title;
            }
            nodeIndexes.Add(title, i - 4);
        }
    }
}
