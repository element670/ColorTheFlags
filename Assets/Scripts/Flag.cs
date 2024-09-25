using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public static readonly string ACTION = "FLAG_ACTION";
    private List<FlagPartTouchDetect> parts = new List<FlagPartTouchDetect>();
    private FlagPartTouchDetect selectedPart;
    
    void Start()
    {
        EventBus.Register<FlagPartTouchDetect>(FlagPartTouchDetect.ACTION, ColorThePart);
        
        foreach (Transform t in transform)
            parts.Add(t.GetComponent<FlagPartTouchDetect>());
    }
    private void ColorThePart(FlagPartTouchDetect touchDetect)
    {
        selectedPart = touchDetect;
        EventBus.Trigger(ACTION, this);
    }

    public void SetPartColor(Material colorMaterial)
    {

        selectedPart.SetColor(colorMaterial);
        
        bool isSelected = true;
        foreach(var part in parts)
        {
            if(!part.IsUserSetColor())
            { 
                isSelected = false;
                break;
            }
        }

        if (isSelected)
        {
            bool result = true;

            foreach (var part in parts)
            {
                if (!part.CheckIdentity())
                {
                    result = false;
                    break;
                }
            }

            if (result)
            {
                print("victory");
            }
            else
                print("reset");
        }

    }
    public void Reset()
    {
        foreach (var part in parts)
        {
            part.Reset();
        }
    }
}
