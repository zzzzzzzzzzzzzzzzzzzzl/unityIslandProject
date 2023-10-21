using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Chunk
{
    double height;

    public Tile[][] tileArr;
    public int[] pos;
    public Color mapColourVariation;

    public Chunk(int x, int y, GameObject parent)
    {
        float rfloat = UnityEngine.Random.Range(0, .1f);
        mapColourVariation = new Color(rfloat, rfloat, rfloat);
        height = World.height;
        tileArr = genChunk(parent, x * World.chunkSize, y * World.chunkSize);
        pos = new int[] { x, y };
    }

    Tile[][] genChunk(GameObject parent, int x, int y)
    {
        float[][] perlinNoise = PerlinNoise.GeneratePerlinNoise(World.chunkSize, x, y, 10);

        tileArr = new Tile[World.chunkSize][];
        for (int i = 0; i < World.chunkSize; i++)
        {
            tileArr[i] = new Tile[World.chunkSize];
            for (int j = 0; j < World.chunkSize; j++)
            {
                float n = perlinNoise[i][j];

                float h = getHeight(x + j, i + y);
                n += h;
                tileArr[i][j] = new Tile(i + y, j + x, n, parent);
            }
        }
        return tileArr;
    }

    public List<Vector3> dirtList()
    {
        List<Vector3> list = new List<Vector3>();
        foreach (Tile[] tiles in tileArr)
        {
            foreach (Tile tile in tiles)
            {
                if (tile.tileData.type == "dirt")
                {
                    list.Add(tile.pos);
                    tile.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }
        return list;
    }

    public void highlight(Color colour)
    {
        foreach (Tile[] tileArr in tileArr)
        {
            foreach (Tile tile in tileArr)
            {
                tile.gameObject.GetComponent<Renderer>().material.color =
                    tile.tileData.color + colour;
            }
        }
    }

    float getHeight(double x, double y)
    {
        x -= 16;
        y -= 16;
        double n = Math.Sqrt((x * x) + (y * y));
        double k = 0;
        if (n < height)
        {
            k = Math.Sqrt((height * height) - (n * n)) / World.height;
            k = (k + .1) * (k + .1) * .2f;
        }
        return (float)(k);
    }
}
