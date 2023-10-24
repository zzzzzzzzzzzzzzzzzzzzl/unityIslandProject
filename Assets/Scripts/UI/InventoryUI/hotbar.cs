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
    public GameObject hotbarSlotPrefab;
    GameObject[] hotbarSlot;
    public GameObject cursor;

    public static Color nonhighlightColor = new Color(0, 0, 0, 0);

    int selected = 1;

    public void Start()
    {
        // Debug.Log(transform.parent.parent.parent.name);
        inv = transform.parent.parent.parent.GetComponent<player>().inv;
        int x = inv.items.GetLength(0);
        hotbarSlot = new GameObject[x];
        layout.initInventory(transform.gameObject, x, 1);

        for (int i = 0; i < x; i++)
        {
            hotbarSlot[i] = Instantiate(hotbarSlotPrefab);
            if (inv.items[0, i] != null)
            {
                hotbarSlot[i].GetComponent<ItemSlot>().UpdatePNGTexture(inv.items[0, i]);
            }
            hotbarSlot[i].transform.SetParent(transform);
        }
        cursor.GetComponent<RectTransform>().sizeDelta = new Vector2(ItemSlot.size, ItemSlot.size);
        updateHotbarCursor();
    }

    public void Update()
    {
        int numdown = InputManager.getKeyNumber();
        if (numdown != 10)
        {
            selected = numdown;
        }
        handleScrollWheel();
        updateHotbarCursor();
    }

    void updateHotbarCursor()
    {
        if (selected != 10)
        {
            if (selected < 1 + transform.childCount) //hotbarSlot.Length)
                cursor.GetComponent<RectTransform>().position = transform
                    .GetChild(selected - 1) //-1 beacuse of array index
                    .GetComponent<RectTransform>()
                    .position;
        }
    }

    void handleScrollWheel()
    {
        int input = -(int)(InputManager.navigateHotbar() * 10);
        selected += input;
        if (selected < 1)
        {
            selected = transform.childCount;
        }
        if (selected > transform.childCount)
        {
            selected = 1;
        }
    }
}
