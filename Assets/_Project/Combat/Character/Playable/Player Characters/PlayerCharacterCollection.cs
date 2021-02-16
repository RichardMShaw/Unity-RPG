using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "PlayerCharacterDatabase",
        menuName = "Database/PlayerCharacterDatabase",
        order = 0)
]
public class PlayerCharacterCollection : ScriptableObject
{
    public List<Player> characters;

    public Dictionary<string, int> indexs;

    public Player get(string id)
    {
        if (indexs.ContainsKey(id))
        {
            return characters[indexs[id]];
        }
        return null;
    }

    private void Awake()
    {
        if (characters == null)
        {
            characters = new List<Player>();
        }
        if (indexs == null)
        {
            indexs = new Dictionary<string, int>();
            for (int i = characters.Count - 1; i > -1; i--)
            {
                indexs.Add(characters[i].id, i);
            }
        }
    }
}
