using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Item{
    ItemData ItemData;
    Item(string key){
        ItemData=ItemIndex.index[key];
    }
}

public class ItemData : MonoBehaviour
{
    public string type;
    public Color color;
    public bool walkable;
}

public class ItemIndex : MonoBehaviour
{
    public static Dictionary<string, ItemData> index = new Dictionary<string, ItemData>
    {
        ["seeds"] = new ItemData
        {
            type = "seeds",
            color = new Color(.33f, 0.676f, 0.32f),
            walkable = true
        },
        ["grain"] = new ItemData
        {
            type = "water",
            color = new Color(.23f, 0.376f, 0.62f),
            walkable = false
        }
    };
}
