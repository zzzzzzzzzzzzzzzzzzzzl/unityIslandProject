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
    Tile currentTile;
    Chunk chunk;
    Chunk[][] surroundingChunks;
    Tile[][] surroundingTiles;
    Inventory inv;
    Dictionary<(int x, int y), Chunk> chunkDict;
    public float speed = .2f;

    void Start()
    {
        chunkDict = transform.parent.GetComponent<World>().chunkDict;
        entityData = EntityIndex.index["player"];
        initGameObject();
        UI.GetComponent<UIManager>().init(chunkDict);
        transform.position = getRandomDirtTile(2);
    }

    void Update()
    {
        float x = transform.position.x / World.chunkSize;
        float z = transform.position.z / World.chunkSize;


        if (surroundingChunks != null)
        {
            foreach (Chunk[] c in surroundingChunks)
            {
                foreach (Chunk k in c)
                {
                    k.highlight(new Color(0, 0, 0));
                }
            }
        }
        surroundingChunks = Entity.surroundingChunks(chunkDict, x, z);
        chunk = surroundingChunks[1][1];
        surroundingTiles = Entity.surroundingTiles(surroundingChunks);
        movePlayer();
        chunk.highlight(Color.red);
    }
    void initGameObject()
    {
        playerModel.transform.GetComponent<Renderer>().material.color = entityData.color;
    }

    void movePlayer()
    {
        float x = transform.position.x % World.chunkSize; //should be optomized
        float z = transform.position.z % World.chunkSize; //might actually be ok

        tileShift(x, z);
        Vector3 input = InputManager.playerMovementInputs() * speed;
        if (surroundingTiles[(int)(x + input.x) + World.chunkSize][(int)(z + input.z) + World.chunkSize].tileData.walkable)
        {
            transform.position += input;
        }

    }

    void chunkShift(float x, float z)
    {
        Chunk previousChunk = null;
        if (chunk != null)
        {
            previousChunk = chunk;
        }
        chunk = chunkDict[((int)z, (int)x)];

        if (previousChunk != chunk)
        {
            if (previousChunk != null)
            {
                previousChunk.highlight(new Color(0, 0, 0));
            }
        }
    }

    void tileShift(float x, float z)
    {
        if (x < 0)
        {
            x = x + World.chunkSize - 1;
        }
        if (z < 0)
        {
            z = z + +World.chunkSize - 1;
        }
        currentTile = chunk.tileArr[(int)x][(int)z];
        currentTile.gameObject.GetComponent<Renderer>().material.color = currentTile.tileData.color;
    }


    Vector3 getRandomDirtTile(int chunks)
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
