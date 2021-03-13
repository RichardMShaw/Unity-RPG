using System.Collections.Generic;

public class SkillHandler
{
    public Queue<SkillQueueSlot> skillQueue;

    public bool allowAdd;

    public void add(SkillQueueSlot slot)
    {
        if (allowAdd)
        {
            skillQueue.Enqueue (slot);
        }
    }

    public void pop()
    {
        SkillQueueSlot curr = skillQueue.Dequeue();
        while (curr != null)
        {
            curr.cast();
            curr = skillQueue.Dequeue();
        }
    }

    public void clear()
    {
        skillQueue.Clear();
    }
}
