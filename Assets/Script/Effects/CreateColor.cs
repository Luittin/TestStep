using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateColor : MonoBehaviour
{
    public static void RandomColor(Material material)
    {
        float H, S, V;
        Color.RGBToHSV(material.GetColor("Color_D0D93088"), out H, out S, out V);
        H = Random.Range(0.0f,1.0f);
        material.SetColor("Color_D0D93088", Color.HSVToRGB(H, S, V));
    }

    public static void AddColorH(Material material)
    {
        float H, S, V;

        Color.RGBToHSV(material.GetColor("Color_D0D93088"), out H, out S, out V);
        H += 0.015f;
        if (H > 1) H -= 1;
        material.SetColor("Color_D0D93088", Color.HSVToRGB(H, S, V));
    }
}
