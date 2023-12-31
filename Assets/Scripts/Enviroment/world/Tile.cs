using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile
{
    public Vector3 pos;
    public Color color;

    float noise;

    public GameObject gameObject;
    public TileData tileData;

    public Tile(float x, float y, float perlinNoise, GameObject parent)
    {
        color = new Color(perlinNoise, perlinNoise, perlinNoise);
        pos = new Vector3(x, 0, y);

        float tolerance = 0.5f;
        if (perlinNoise < tolerance)
        {
            tileData = TileIndex.index["water"];
        }
        else
        {
            tileData = TileIndex.index["grass"];
        }
        gameObject = genTileObject(perlinNoise, parent);
        updateRenderer();
    }

    GameObject genTileObject(float perlinNoise, GameObject parent)
    {
        // gameObject = GameObject.Instantiate(parent.transform.GetChild(0).gameObject); //
        gameObject = MeshGen.plane();
        gameObject.transform.SetParent(parent.transform);
        gameObject.transform.position = pos;
        gameObject.name = tileData.type;
        return gameObject;
    }

    public void updateRenderer()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = tileData.color;
        renderer.material.SetFloat("_Glossiness", .0f);
    }

    public void swapTile(string key)
    {
        tileData = TileIndex.index[key];
        gameObject.GetComponent<Renderer>().material.color = tileData.color;
    }
}

public class TileData
{
    public string type;
    public Color color;
    public bool walkable;
}

public static class TileIndex
{
    public static Dictionary<string, TileData> index = new Dictionary<string, TileData>
    {
        ["grass"] = new TileData
        {
            type = "grass",
            color = new Color(.33f, 0.676f, 0.32f),
            walkable = true
        },
        ["dirt"] = new TileData
        {
            type = "dirt",
            color = new Color(.33f, 0.476f, 0.32f),
            walkable = true
        },
        ["water"] = new TileData
        {
            type = "water",
            color = new Color(.23f, 0.376f, 0.62f),
            walkable = false
        }
    };
}
