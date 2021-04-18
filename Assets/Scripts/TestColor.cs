using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColor : MonoBehaviour
{
    SpriteRenderer mSpriteRenderer;
  
    Texture2D mColorSwapTex;
    Color[] mSpriteColors;

    public void InitColorSwapTex()
    {
        Texture2D colorSwapTex = new Texture2D(256, 1, TextureFormat.RGBA32, false, false);
        colorSwapTex.filterMode = FilterMode.Point;

        for (int i = 0; i < colorSwapTex.width; ++i)
            colorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));

        colorSwapTex.Apply();

        mSpriteRenderer.material.SetTexture("_SwapTex", colorSwapTex);

        mSpriteColors = new Color[colorSwapTex.width];
        mColorSwapTex = colorSwapTex;
    }

    
    public void SwapColor(int index, Color color)
    {
        mSpriteColors[index] = color;
        mColorSwapTex.SetPixel(index, 0, color);
    }

    private void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();

        InitColorSwapTex();
      
        for (int i = 0; i < 255; i++)
        {
            SwapColor(i, GameManager.GetInstance().getColors()[i]);
        }

        mColorSwapTex.Apply();
    }

    public void swapNewColors()
    {
        for (int i = 0; i < 255; i++)
        {
            SwapColor(i, GameManager.GetInstance().getColors()[i]);
        }

        mColorSwapTex.Apply();
    }
}
