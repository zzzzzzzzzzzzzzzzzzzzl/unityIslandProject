using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public static int sprite = 64; //32 is sprite size+2 is frame size+4 for spacing
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

        // pngTexture();
    }

    public void UpdatePNGTexture(Item item)
    {
        Texture2D texture = new Texture2D(1, 1);

        byte[] pngBytes = File.ReadAllBytes(item.ItemData.spritePath);
        if (texture.LoadImage(pngBytes))
        {
            RawImage rawImage = itemSprite.GetComponent<RawImage>();
            rawImage.color = Color.white;
            texture.filterMode = FilterMode.Point;
            rawImage.texture = texture;
        }
    }
}
