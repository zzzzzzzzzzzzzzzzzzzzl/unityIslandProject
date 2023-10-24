using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    EntityIndexData entityData;
    bool displayUI = false;
    public GameObject playerModel;
    public GameObject UI;
    Chunk chunk;
    Chunk[,] surroundingChunks;
    Tile[,] surroundingTiles;
    Inventory inv;
    Tile tile;
    Dictionary<(int x, int y), Chunk> chunkDict;

    public float speed = .2f;

    void Start()
    {
        chunkDict = transform.parent.GetComponent<World>().chunkDict;
        entityData = EntityIndex.index["player"];
        UI.GetComponent<UIManager>().init(chunkDict);
        transform.position = getRandomDirtTile(2);
        playerModel.transform.GetComponent<Renderer>().material.color = entityData.color;
    }

    void Update()
    {
        float Chunkx = transform.position.x / World.chunkSize;
        float Chunkz = transform.position.z / World.chunkSize;

        float Tilex = transform.position.x % World.chunkSize; //should be optomized
        float Tilez = transform.position.z % World.chunkSize; //might actually be ok

        surroundingChunks = Entity.surroundingChunks(chunkDict, Chunkx, Chunkz);
        surroundingTiles = Entity.surroundingTiles(surroundingChunks);

        if (chunk != null)
        {
            chunk.highlight(new Color(0, 0, 0));
        }

        chunk = surroundingChunks[1, 1];
        tile = surroundingTiles[(int)(Tilex) + World.chunkSize, (int)(Tilez) + World.chunkSize];
        // tile.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0, 0);
        // highlightSurroundingChunks();
        movePlayer();
        chunk.highlight(Color.red);
        InputManager.interactWithTile(tile);
    }

    void movePlayer()
    {
        float x = transform.position.x % World.chunkSize; //should be optomized
        float z = transform.position.z % World.chunkSize; //might actually be ok

        // tileShift(x, z);//updates playerTile
        Vector3 input = InputManager.playerMovementInputs() * speed;
        if (
            surroundingTiles[
                (int)(x + input.x) + World.chunkSize,
                (int)(z + input.z) + World.chunkSize
            ]
                .tileData
                .walkable
        )
        {
            transform.position += input;
        }
    }

    void interactWithBlock() { }

    void highlightSurroundingChunks(Color color)
    {
        if (surroundingChunks != null)
        {
            for (int i = 0; i < surroundingChunks.GetLength(0); i++)
            {
                for (int j = 0; j < surroundingChunks.GetLength(1); j++)
                {
                    surroundingChunks[i, j].highlight(color);
                }
            }
        }
    }

    Vector3 getRandomDirtTile(int chunks) //probably remove this at some point
    {
        List<Vector3> dirtList = new List<Vector3>();
        for (int i = 0; i < chunks; i++)
        {
            for (int j = 0; j < chunks; j++)
            {
                dirtList.AddRange(chunkDict[(i, j)].dirtList());
            }
        }
        int r = Random.Range(0, dirtList.Count);
        return dirtList[r];
    }
}
