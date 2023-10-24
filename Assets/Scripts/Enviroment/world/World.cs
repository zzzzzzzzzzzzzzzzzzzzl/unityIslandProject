using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    public int load = 8;
    public static int chunkSize = 8;
    public static float height = 128;
    public GameObject imageObject;
    public Dictionary<(int x, int y), Chunk> chunkDict = new Dictionary<(int x, int y), Chunk>();

    public void Start()
    {
        genWorld();
    }

    void genWorld()
    {
        GameObject worldGameObject = new GameObject() { name = "world" };
        worldGameObject.transform.SetParent(transform);

        for (int i = -load; i < load; i++)
            for (int j = -load; j < load; j++)
            {
                {
                    chunkDict.Add((i, j), new Chunk(i, j, worldGameObject));
                }
            }
    }
}
