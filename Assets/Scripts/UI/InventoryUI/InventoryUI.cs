using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inv;
    public GameObject player;
    public GameObject itemSlotPrefab;
    GameObject[,] itemSlot;

    public void Start()
    {
        // inv = transform.parent.transform.GetComponent<Inventory>();
        inv = new Inventory();
        int x = inv.items.GetLength(0);
        int y = inv.items.GetLength(1);
        itemSlot = new GameObject[x, y];
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(x * ItemSlot.size, y * ItemSlot.size);
        transform.GetComponent<GridLayoutGroup>().cellSize = new Vector2(ItemSlot.frame, ItemSlot.frame);

        for (int i = 0; i < x; i++)
        {
            for (int j = 1; j < y; j++)//row 0 of y will be our hotbar
            {
                itemSlot[i, j] = Instantiate(itemSlotPrefab);
                itemSlot[i, j].transform.SetParent(transform);
            }
        }
    }
    public void updateInventoryUI()
    {

    }

}