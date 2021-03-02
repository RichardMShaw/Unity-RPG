using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    public int maxSize;

    [SerializeField]
    List<ItemSlot> items;
}
