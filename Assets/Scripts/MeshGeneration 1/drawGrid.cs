using System;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class RandomColorGrid : MonoBehaviour
{
    public int gridSize = 5;
    public float spacing = 0f;
    public Material[] materials; // Assign materials in the Inspector
    public float[][] noise;
    public GameObject applyTexture;

    void Start()
    {
        PerlinNoise n = new PerlinNoise();
        generateTerrain(0, 0);

    }




    void generateTerrain(int startX, int startY)
    {


        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                float sample = 0;
                // sample = Mathf.PerlinNoise((float)x / 10, (float)z / 10);



                GameObject newGameObject = Instantiate(applyTexture);

                Vector3 position = new Vector3(x * spacing + (startX * gridSize), (float)Math.Round((sample) * 10), z * spacing + (startY * gridSize));
                newGameObject.transform.position = position;


                newGameObject.transform.SetParent(transform);
                Material newmat = new Material(Shader.Find("Standard"));
                newGameObject.GetComponent<Renderer>().sharedMaterial.mainTexture = GenerateNoiseTexture(x * 50, z * 50);

            }
        }
    }
    Texture2D GenerateNoiseTexture(float Xorg, float Yorg, int width = 5, int height = 5, float scale = 1)
    {
        Texture2D texture = new Texture2D(width, height);
        Color[] colorMap = new Color[width * height];

        for (float y = 0; y < height; y++)
        {
            for (float x = 0; x < width; x++)
            {
                float xn = Xorg + x;
                float yn = Yorg + y;
                float sample = Mathf.PerlinNoise(xn / 1.001f, yn / 1.001f);
                colorMap[(int)(y * width + x)] = new Color(sample, sample, sample);
            }
        }

        texture.SetPixels(colorMap);
        texture.Apply();

        return texture;
    }
    Mesh createMesh()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[]
                {
                    new Vector3(0, 0, 0),
                    new Vector3(1, 0, 0),
                    new Vector3(0, 0, 1),
                    new Vector3(1, 0, 1),
                };
        int[] triangles = new int[]
        {
                    0, 2, 1,
                    2, 3, 1,
        };
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        return mesh;
    }
    void CombineMeshes(List<MeshFilter> meshFilters)
    {
        CombineInstance[] combineInstances = new CombineInstance[meshFilters.Count];

        for (int i = 0; i < meshFilters.Count; i++)
        {
            combineInstances[i].mesh = meshFilters[i].sharedMesh;
            combineInstances[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }

        Mesh combinedMesh = new Mesh();
        combinedMesh.CombineMeshes(combineInstances);

        GameObject combinedGameObject = new GameObject("CombinedMesh");
        MeshFilter combinedMeshFilter = combinedGameObject.AddComponent<MeshFilter>();
        MeshRenderer combinedMeshRenderer = combinedGameObject.AddComponent<MeshRenderer>();

        combinedMeshFilter.mesh = combinedMesh;
        combinedGameObject.transform.SetParent(transform);

        // Optionally set the layer
        combinedGameObject.layer = gameObject.layer;
    }
}

