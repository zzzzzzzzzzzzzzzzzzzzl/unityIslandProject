using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI
{
    GameObject map;
    public Inventory inv;

    public InventoryUI(Inventory newInv)
    {
        inv=newInv;
    }
}