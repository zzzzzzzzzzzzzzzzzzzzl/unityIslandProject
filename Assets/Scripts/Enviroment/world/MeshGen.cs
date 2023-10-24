using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour
{
    public static GameObject plane()
    {
        GameObject plane = new GameObject("Plane");
        MeshFilter meshFilter = plane.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = plane.AddComponent<MeshRenderer>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 1),
        };
        mesh.vertices = vertices;
        mesh.triangles = new int[] { 0, 2, 1, 1, 2, 3 };
        meshRenderer.material = new Material(Shader.Find("Standard"));
        return plane;
    }

    public static Material randomColour()
    {
        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.color = new Color();
        newMaterial.SetFloat("_Glossiness", 0.5f);
        Texture2D texture = Resources.Load<Texture2D>("YourTextureName");
        newMaterial.SetTexture("_MainTex", texture);
        return newMaterial;
    }
}
