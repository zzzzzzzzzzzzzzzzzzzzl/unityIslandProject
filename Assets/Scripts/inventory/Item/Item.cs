using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    public ItemData ItemData;

    public Item(string key)
    {
        ItemData = ItemIndex.index[key];
    }
}

public class ItemData
{
    public string type;
    public string spritePath;
}

public static class ItemIndex
{
    public static Dictionary<string, ItemData> index = new Dictionary<string, ItemData>
    {
        ["seeds"] = new ItemData { type = "seeds", spritePath = "Assets/Sprites/sprite (1).png" },
        ["grain"] = new ItemData { type = "grain", spritePath = "Assets/Sprites/sprite (2).png" },
        ["rye"] = new ItemData { type = "rye", spritePath = "Assets/Sprites/sprite (3).png" },
        ["hoe"] = new ItemData { type = "hoe", spritePath = "Assets/Sprites/sprite (4).png" },
        ["bass"] = new ItemData { type = "bass", spritePath = "Assets/Sprites/sprite (5).png" },
        ["trout"] = new ItemData { type = "trout", spritePath = "Assets/Sprites/sprite (6).png" },
        ["pike"] = new ItemData { type = "pike", spritePath = "Assets/Sprites/sprite (7).png" },
        ["coal"] = new ItemData { type = "coal", spritePath = "Assets/Sprites/sprite (8).png" },
        ["grass"] = new ItemData { type = "grass", spritePath = "Assets/Sprites/sprite (9).png" },
        ["dryGrass"] = new ItemData
        {
            type = "dryGrass",
            spritePath = "Assets/Sprites/sprite (10).png"
        },
        ["jar"] = new ItemData { type = "jar", spritePath = "Assets/Sprites/sprite (11).png" },
    };
}
