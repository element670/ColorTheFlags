using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameColor gameColor;
    private Material selectedColor;

    void Start()
    {
        EventBus.Register<GameColor.ColorPalette>(DetectColor.ACTION, IncomingColor);
        EventBus.Register<Flag>(Flag.ACTION, IncomingFlag);
    }

    private void IncomingColor(GameColor.ColorPalette color)
    {
        selectedColor = GameColor.GetMaterialFor(color);
    }
    private void IncomingFlag(Flag flag)
    {
        if (selectedColor != null) 
        {
            flag.SetPartColor(selectedColor); 
        }
    }
}
