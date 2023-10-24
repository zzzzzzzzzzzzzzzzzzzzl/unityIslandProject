using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mapUI;
    public GameObject invUI;
    public GameObject player;

    GameObject active = null;
    Dictionary<(int x, int y), Chunk> chunkDict;

    public void init(Dictionary<(int x, int y), Chunk> newChunkDict)
    {
        chunkDict = newChunkDict;

    }

    void Update()
    {
        active = InputManager.activeUI(active, mapUI, "m");
        if (mapUI.activeSelf)
        {
            // mapUI.updateMapImage(chunkDict);
        }
        active = InputManager.activeUI(active, invUI, "e");
    }

    static void switchActiveUI(GameObject active, GameObject activate)
    {
        active.SetActive(false);
        activate.SetActive(true);
    }
}
