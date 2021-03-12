public class HeroSlot : CharacterSlot
{
    public Hero template;

    public void refresh()
    {
        temporaySlots.Clear();
    }

    public void setTemplate(Hero _template)
    {
        template = _template;
    }
}
