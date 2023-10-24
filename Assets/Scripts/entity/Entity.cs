using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Entity
{
    public static Tile[,] surroundingTiles(Chunk[,] chunkArr)
    {//nice; this took so long
        int matrixSize = World.chunkSize;
        int combinedSize = matrixSize * 3;
        Tile[,] comnbinedMatrix = new Tile[combinedSize,combinedSize];
        for (int i = 0; i < 3; i++)
        {
            int sx = i * matrixSize;
            for (int j = 0; j < 3; j++)
            {
                int sy = j * matrixSize;
                for (int x = 0; x < matrixSize; x++)
                {
                    for (int y = 0; y < matrixSize; y++)
                    {
                        comnbinedMatrix[x + sx,y + sy] = chunkArr[j,i].tileArr[x,y];
                    }
                }
            }
        }
        return comnbinedMatrix;
    }

    public static Chunk[,] surroundingChunks(
        Dictionary<(int x, int y), Chunk> chunkDict,
        float x,
        float z
    )
    {
        Chunk[,] chunkArr = new Chunk[3,3];
        if (x < 1)
        {
            x--;
        }
        if (z < 1)
        {
            z--;
        }
        for (int i = 0; i < 3; i++)
        {
            // chunkArr[i] = new Chunk[3];

            for (int j = 0; j < 3; j++)
            {
                chunkArr[i,j] = chunkDict[(i + (int)z - 1, j + (int)x - 1)];
            }
        }
        return chunkArr;
    }
}

public class EntityIndexData : MonoBehaviour
{
    public string type;
    public float speed;
    public Color color;
}

public class EntityIndex : MonoBehaviour
{
    public static Dictionary<string, EntityIndexData> index = new Dictionary<
        string,
        EntityIndexData
    >
    {
        ["player"] = new EntityIndexData
        {
            type = "player",
            speed = 1f,
            color = new Color(.9f, .1f, .2f)
        },
    };
}
