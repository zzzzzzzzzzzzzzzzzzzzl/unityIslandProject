using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class mapUI
{
    GameObject map;
    public GameObject player;
    public mapUI(GameObject newMap, Dictionary<(int x, int y), Chunk> chunkDict, GameObject p)
    {
        map = newMap;
        player = p;
        map = updateMapImage(chunkDict);
    }
    public Sprite getMapSprite(Dictionary<(int x, int y), Chunk> chunkDict, int load = 4)
    {
        Texture2D textureMap = new Texture2D(World.chunkSize * load, World.chunkSize * load);
        for (int i = 0; i < load; i++)
        {
            for (int j = 0; j < load; j++)
            {
                Chunk chunk = chunkDict[(i, j)];

                for (int rowIndex = 0; rowIndex < chunk.tileArr.Length; rowIndex++)
                {
                    Tile[] tileArr = chunk.tileArr[rowIndex];

                    for (int columnIndex = 0; columnIndex < tileArr.Length; columnIndex++)
                    {
                        Tile tile = tileArr[columnIndex];
                        textureMap.SetPixel((int)tile.pos.x, (int)tile.pos.z, tile.tileData.color + chunk.mapColourVariation);
                    }
                }
            }
        }
        textureMap = addPlayerPixel(textureMap);
        textureMap.filterMode = FilterMode.Point;
        textureMap.Apply();
        return Sprite.Create(textureMap, new Rect(0, 0, textureMap.width, textureMap.height), new Vector2(0.5f, 0.5f)); ;
    }
    Texture2D addPlayerPixel(Texture2D textureMap)
    {
        textureMap.SetPixel((int)player.transform.position.x, (int)player.transform.position.z, Color.red);
        return textureMap;
    }
    public GameObject updateMapImage(Dictionary<(int x, int y), Chunk> chunkDict)
    {
        map.GetComponent<Image>().sprite = getMapSprite(chunkDict);
        return map;
    }
}