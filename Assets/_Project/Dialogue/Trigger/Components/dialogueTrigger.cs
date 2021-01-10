using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    private dialogueManager dialogueManager;
    public startNode start;

    private void Start() {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<dialogueManager>();
    }

    public void run(){
        dialogueManager.startDialogue(start);
    }
}
