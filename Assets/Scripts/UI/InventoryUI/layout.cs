using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class layout
{
    public static void setcomponentSize(RectTransform ui, int x, int y)
    {
        ui.sizeDelta = new Vector2(x * ItemSlot.size, y * ItemSlot.size);
    }

    public static void setGridLayout(GridLayoutGroup gridLayout)
    {
        gridLayout.cellSize = new Vector2(ItemSlot.frame, ItemSlot.frame);
        gridLayout.spacing = new Vector2(ItemSlot.spacing, ItemSlot.spacing);
    }

    public static void initInventory(GameObject ui, int x, int y)
    {
        setGridLayout(ui.GetComponent<GridLayoutGroup>());
        setcomponentSize(ui.GetComponent<RectTransform>(), x, y);
    }
}
