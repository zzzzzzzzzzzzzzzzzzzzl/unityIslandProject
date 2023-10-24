using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Inventory
{
    public Item[,] items;
    public int size;
    public int count;

    // public Dictionary<Item,(int,int)> itemDict=new Dictionary<Item, (int, int)>

    public Inventory(int setSize = 4)
    {
        size = setSize;
        items = new Item[size, size];
        for (int i = 0; i < 8; i++)
        {
            addItem(new Item("seeds"));
        }
        for (int i = 0; i < size; i++)
        {
            string s = "";
            for (int j = 0; j < size; j++)
            {
                if (items[i, j] != null)
                {
                    s += items[i, j].ItemData.type;
                }
            }
            Debug.Log(s);
        }
    }

    public void addItem(Item item)
    {
        (int, int) xy = emptySlot();
        if (xy.Item1 != -1)
        {
            items[xy.Item1, xy.Item2] = item;
        }
    }

    public int countInv()
    {
        count = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (items[i, j] == null)
                {
                    count++;
                }
            }
        }
        return size - count;
    }

    public (int, int) emptySlot()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (items[i, j] == null)
                {
                    return (i, j);
                }
            }
        }
        return (-1, -1);
    }
}
