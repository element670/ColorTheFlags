using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameColor: MonoBehaviour 
{
    private static Material matRed;
    private static Material matGreen;
    private static Material matBlue;

    public Material materialRed;
    public Material materialgreen;
    public Material materialBlue;

    private void Awake()
    {
        matRed = materialRed;
        matGreen = materialgreen;
        matBlue = materialBlue;
    }

    public enum ColorPalette
    {
        red, green, blue
    }

    public static Material GetMaterialFor(ColorPalette color)
    {
        Material material = matRed;
        switch (color)
        {
            case ColorPalette.red:
                material = matRed;
                break;
            case ColorPalette.green:
                material = matGreen;
                break;
            case ColorPalette.blue:
                material = matBlue;
                break;
        }

        return material;
    }
}

