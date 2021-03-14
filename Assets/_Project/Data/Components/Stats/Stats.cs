public class Stats
{
    public MaxHealth maxHealth;

    public Attack attack;

    public Undispellable undispellable;

    public Unclearable unclearable;

    public Lasting lasting;

    public Persistence persistence;

    public void copyBaseStats(BaseStats baseStats)
    {
        maxHealth.baseValue = baseStats.maxHealth;
        attack.baseValue = baseStats.attack;
        undispellable.baseValue = baseStats.undispellable;
        unclearable.baseValue = baseStats.unclearable;
        lasting.baseValue = baseStats.lasting;
        persistence.baseValue = baseStats.persistence;
    }

    public void removeAllModifiers()
    {
        maxHealth.removeAllModifiers();
        attack.removeAllModifiers();
        undispellable.removeAllModifiers();
        unclearable.removeAllModifiers();
        lasting.removeAllModifiers();
        persistence.removeAllModifiers();
    }
}
