using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{

    public Item[,] items;
    public int size;
    public Inventory(int setSize = 7)
    {
        size = setSize;
        items = new Item[size, size];
    }
}