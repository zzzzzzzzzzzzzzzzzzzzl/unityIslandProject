using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class hotbar : MonoBehaviour
{
    Inventory inv;
    public GameObject player;
    public GameObject itemSlotPrefab;
    GameObject[,] itemSlot;

    public void Start()
    {

        inv = new Inventory();
        int x = inv.items.GetLength(0);
        int y = inv.items.GetLength(1);
        itemSlot = new GameObject[x, y];
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(x * ItemSlot.size, ItemSlot.size);
        for (int i = 0; i < x; i++)
        {
            itemSlot[i, 0] = Instantiate(itemSlotPrefab);
            itemSlot[i, 0].transform.SetParent(transform);
        }
        transform.GetComponent<GridLayoutGroup>().cellSize = new Vector2(ItemSlot.frame, ItemSlot.frame);
    }
}