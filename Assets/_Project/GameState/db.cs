using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class db : MonoBehaviour
{
    [Serializable]
    public struct Flag
    {
        public string key;

        public int val;
    }

    public Flag[] flags;

    public Dictionary<string, int> flagKeys;

    [Serializable]
    public struct Item
    {
        public string name;

        public int val;
    }

    [Serializable]
    public struct Items
    {
        public string key;

        public Item item;
    }

    public Items[] items;

    public Dictionary<string, int> itemKeys;

    public void setFlagVal(string key,int val){
        flags[flagKeys[key]].val = val;
    }

    public int getFlagVal(string key){
        return flags[flagKeys[key]].val;
    }

    public void setItemVal(string key,int val){
        items[itemKeys[key]].item.val = val;
    }

    private void Start()
    {
        flagKeys = new Dictionary<string, int>();
        itemKeys = new Dictionary<string, int>();
        for (int i = flags.Length - 1; i > -1; i--)
        {
            flagKeys.Add(flags[i].key, i);
        }

        for (int i = items.Length - 1; i > -1; i--)
        {
            itemKeys.Add(items[i].key, i);
        }
    }
}
