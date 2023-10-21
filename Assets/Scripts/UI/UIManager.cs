using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    mapUI mapUI;
    public GameObject map;
    
    InventoryUI invUI;
    public GameObject inv;
    public GameObject player;

    GameObject active=null;
    Dictionary<(int x, int y), Chunk> chunkDict;

    public void init(Dictionary<(int x, int y), Chunk> newChunkDict)
    {
        chunkDict = newChunkDict;
        mapUI = new mapUI(map, chunkDict, player);
    }

    void Update()
    {
        active=InputManager.activeUI(active,map, "m");
        if (map.activeSelf)
        {
            mapUI.updateMapImage(chunkDict);
        }
         active= InputManager.activeUI(active,inv, "e");
    }

    static void switchActiveUI(GameObject active,GameObject activate){
        active.SetActive(false);
        activate.SetActive(true);
    }
}
