using UnityEngine;

[
    CreateAssetMenu(
        fileName = "BattleLoadout",
        menuName = "Combat/Battle Loadout",
        order = 0)
]
public class BattleLoadout : ScriptableObject
{
    public Field field;

    public EnemyGroup enemyGroup;

    public AllyGroup allyGroup;
}
