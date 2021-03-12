public class AllySlot : CharacterSlot
{
    public Ally template;

    public void refresh()
    {
        temporaySlots.Clear();
    }

    public void setTemplate(Ally ally)
    {
        template = ally;
    }
}
