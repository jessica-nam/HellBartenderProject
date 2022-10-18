using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectHairColor : MonoBehaviour
{
    [Header("Color values")]
    public float redAmount;
    public float greenAmount;
    public float blueAmount;

    public Image colorImage;
    
    public List<SpriteRenderer> rendererList = new List<SpriteRenderer>();

    private Color currentHairColor;
    
    private void Awake()
    {
        colorImage = GetComponent<Image>();
        redAmount = colorImage.color.r;
        greenAmount = colorImage.color.g;
        blueAmount = colorImage.color.b;
    }

    public void SetHairColor()
    {
        currentHairColor = new Color(redAmount, greenAmount, blueAmount);

        for (int i = 0; i < rendererList.Count; i++)
        {
            //rendererList[i].material.SetColor("_Color", currentHairColor);
            rendererList[i].color = currentHairColor;
        }
    }
}
