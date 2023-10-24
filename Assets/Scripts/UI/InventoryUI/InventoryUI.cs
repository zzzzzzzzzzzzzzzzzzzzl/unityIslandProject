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
        inv = transform.parent.parent.GetComponent<player>().inv;
        int x = inv.items.GetLength(0);
        int y = inv.items.GetLength(1);
        itemSlot = new GameObject[x, y];
        layout.initInventory(transform.gameObject, x, y);

        for (int i = 0; i < x; i++)
        {
            for (int j = 1; j < y; j++) //row 0 of y will be our hotbar
            {
                itemSlot[i, j] = Instantiate(itemSlotPrefab);
                if (inv.items[i, j] != null)
                {
                    itemSlot[i, j].GetComponent<ItemSlot>().UpdatePNGTexture(inv.items[i, j]);
                }
                itemSlot[i, j].transform.SetParent(transform);
            }
        }
    }

    public void updateInventoryUI() { }
}
