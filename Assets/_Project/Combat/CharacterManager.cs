using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private Queue<SkillQueueSlot> skillQueue;

    [SerializeField]
    public List<CharacterSlot> characters;

    private void Start()
    {
        GameEvents.events.onTurnEnd += turnEnd;
        GameEvents.events.onAddSkillToQueue += addSkillToQueue;
        skillQueue = new Queue<SkillQueueSlot>();
    }

    private void processSkillQueue()
    {
        while (skillQueue.Count > 0)
        {
            skillQueue.Dequeue().use();
        }
    }

    private void addSkillToQueue(SkillQueueSlot slot)
    {
        skillQueue.Enqueue (slot);
    }

    //Events

    private void turnEnd()
    {
        int len = characters.Count;
        for (int i = 0; i < len; i++)
        {
            CharacterSlot slot = characters[i];
            slot.events.turnEnd (slot);
            processSkillQueue();
        }
    }
}
