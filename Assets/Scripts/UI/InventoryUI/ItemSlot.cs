using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    public static int sprite = 64;//32 is sprite size+2 is frame size+4 for spacing
    public static int frame = sprite + 2;
    public static int spacing = 4;
    public static int size = frame + spacing;
    // public static int size = 64 + 2 + 4;//32 is sprite size+2 is frame size+4 for spacing

    public GameObject itemSprite;
    public void Start()
    {
        transform.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(frame, frame);
        itemSprite.GetComponent<RectTransform>().sizeDelta = new Vector2(sprite, sprite);

        RawImage rawImage = gameObject.GetComponent<RawImage>();
        rawImage.texture.filterMode = FilterMode.Point;

        pngTexture();
    }
    public void updateInventoryUI()
    {

    }

    Texture2D pngTexture()
    {
        Texture2D texture = new Texture2D(1, 1);
        int ran = Random.Range(1, 1000);
        byte[] pngBytes = File.ReadAllBytes($"Assets/Sprites/sprite ({ran}).png");
        if (texture.LoadImage(pngBytes))
        {
            RawImage rawImage = itemSprite.GetComponent<RawImage>();
            texture.filterMode = FilterMode.Point;
            rawImage.texture = texture;

        }
        return texture;
    }
}