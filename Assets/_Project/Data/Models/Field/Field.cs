using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Field", menuName = "Combat/Field", order = 0)]
public class Field : ScriptableObject
{
    public string label;

    public Image background;

    public AllyTeam allyTeam;

    public EnemyTeam enemyTeam;

    public List<CharacterSlot> getAllCharacterSlots()
    {
        return null;
    }
}
