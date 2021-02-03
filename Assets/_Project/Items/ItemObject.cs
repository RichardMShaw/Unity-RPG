using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Item,
    Weapon,
    Armor,
    Accessory,
    Currency,
    Material,
    Key
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;

    public string id;

    public ItemType type;

    [TextArea(15, 20)]
    public string description;
}
