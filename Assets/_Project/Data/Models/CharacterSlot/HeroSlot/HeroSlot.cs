public class HeroSlot : CharacterSlot
{
    public Hero template;

    public int actionPoint;

    public void refresh()
    {
        temporayStatusEffectSlots.Clear();
    }

    public void setTemplate(Hero _template)
    {
        template = _template;
    }
}
