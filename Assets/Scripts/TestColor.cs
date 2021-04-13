﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColor : MonoBehaviour
{
    public SpriteRenderer mSpriteRenderer;

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

    //public enum SwapIndex
    //{
    //    Uno = 07,
    //    Dos = 38,       
    //    Tres = 177,      
    //}

    //public void SwapColor(SwapIndex index, Color color)
    //{
    //    mSpriteColors[(int)index] = color;
    //    mColorSwapTex.SetPixel((int)index, 0, color);
    //}
    public void SwapColor(int index, Color color)
    {
        mSpriteColors[index] = color;
        mColorSwapTex.SetPixel(index, 0, color);
    }

    private void Start()
    {
        InitColorSwapTex();
        for (int i=0; i<255; i++)
        {
            SwapColor(i, Random.ColorHSV());
        }
        //SwapColor(SwapIndex.Uno, new Color(45f, 45f, 45f));      
        //SwapColor(SwapIndex.Tres, Color.yellow);      
        //SwapColor(SwapIndex.Dos, Color.blue);
        mColorSwapTex.Apply();
    }
}
