using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DetectColor : MonoBehaviour
{
    public static readonly string ACTION = "ACTION_CLICK";

    [SerializeField]
    private GameColor.ColorPalette color;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            EventBus.Trigger(ACTION, color);
        });
    }
}


