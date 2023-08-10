using Sirenix.OdinInspector;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public EnumColor color, currentColor;
    public bool vacham;

    public void Reset()
    {
        currentColor = EnumColor.White;
        SetColor();
    }

    public void SetColor(EnumColor enumColor)
    {
        //todo: Phai xoa
        //color = enumColor;
        currentColor = enumColor;
        SetColor();
    }

    public SpriteRenderer spriteRenderer;

    [Button]
    public void SetColorLevel(EnumColor enumColor)
    {
        currentColor = enumColor;
        color = enumColor;
        SetColor();
    }

    public void SetColor()
    {
        switch (currentColor)
        {
            case EnumColor.White:
                spriteRenderer.color = Color.white;
                break;
            case EnumColor.Blue:
                spriteRenderer.color = Color.blue;
                break;
            case EnumColor.Yellow:
                spriteRenderer.color = Color.yellow;
                break;
            case EnumColor.Red:
                spriteRenderer.color = Color.red;
                break;
            case EnumColor.Green:
                spriteRenderer.color = Color.green;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Car"))
        {
            //todo: uncomment
            vacham = true;
            SetColor(col.gameObject.GetComponent<car>().color);
        }
    }

    public bool Check()
    {
        return color == currentColor;
    }
}