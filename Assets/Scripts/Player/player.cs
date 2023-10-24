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
    Tile tile;
    public Inventory inv = new Inventory(4);
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
        float chunkX = transform.position.x / World.chunkSize;
        float chunkZ = transform.position.z / World.chunkSize;

        float x = transform.position.x % World.chunkSize; //should be optomized
        float z = transform.position.z % World.chunkSize; //might actually be ok

        if (surroundingChunks != null)
        {
            for (int i = 0; i < surroundingChunks.GetLength(0); i++)
            {
                for (int j = 0; j < surroundingChunks.GetLength(1); j++)
                {
                    surroundingChunks[i, j].highlight(new Color(0, 0, 0));
                }
            }
        }
        surroundingChunks = Entity.surroundingChunks(chunkDict, chunkX, chunkZ);
        chunk = surroundingChunks[1, 1];
        surroundingTiles = Entity.surroundingTiles(surroundingChunks);

        tile = surroundingTiles[(int)(x) + World.chunkSize, (int)(z) + World.chunkSize];

        InputManager.interactWithTile(tile);
        movePlayer();
        chunk.highlight(Color.red);
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
