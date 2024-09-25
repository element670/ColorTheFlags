using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameColor;
public class FlagPartTouchDetect : MonoBehaviour, IPointerClickHandler
{
    public static readonly string ACTION = "FLAG_PART";
    
    [SerializeField] 
    private GameColor.ColorPalette originalColor;

    private Material userSelectedMaterial;
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Reset();
    }

    public void OnPointerClick(PointerEventData eventdata)
    {
        print(name + " was clicked");
        EventBus.Trigger(ACTION, this);
        
    }
    public void SetColor(Material coloraterial)
    {
        _spriteRenderer.material = coloraterial;
        userSelectedMaterial = coloraterial;
    }
    public void Reset()
    {
        _spriteRenderer.material = GameColor.GetMaterialFor(originalColor);
    }

    public bool CheckIdentity()
    {
        return GameColor.GetMaterialFor(originalColor) == userSelectedMaterial;
    }

    public bool IsUserSetColor()
    {
        return userSelectedMaterial != null;
    }
}



