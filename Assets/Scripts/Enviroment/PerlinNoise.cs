using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public static float[][] GeneratePerlinNoise(int size, int Xorg, int Yorg, float scale = 1)
    {
        float offset = -100000;
        float[][] arr = new float[size][];

        for (int i = 0; i < size; i++)
        {
            arr[i] = new float[size];
            for (int j = 0; j < size; j++)
            {
                float xn = Xorg + j + offset;
                float yn = Yorg + i + offset;

                float sample = Mathf.PerlinNoise(xn / scale, yn / scale);
                arr[i][j] = sample;
            }
        }
        return arr;
    }
    public static float[][] generateLayerdNoise(int size, int Xorg, int Yorg, int layers)
    {
        float[][] layerdNoise = new float[size][];
        for (int i = 0; i < size; i++)
        {
            layerdNoise[i] = new float[size];
        }
        for (int i = 1; i < layers; i++)
        {
            float[][] noise = PerlinNoise.GeneratePerlinNoise(size, Xorg, Yorg, 5 + (i * 10));
            for (int j = 0; j < noise.Length; j++)
            {
                for (int k = 0; k < noise[j].Length; k++)
                {
                    layerdNoise[j][k] += noise[j][k];
                }
            }
        }
        return layerdNoise;
    }
}