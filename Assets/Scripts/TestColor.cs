using System.Collections;
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

    public enum SwapIndex
    {
        Outline = 25,
        SkinPrim = 255,
        SkinSec = 254,
        HandPrim = 235,
        HandSec = 204,
        ShirtPrim = 62,
        ShirtSec = 70,
        ShoePrim = 253,
        ShoeSec = 248,
        Pants = 72,
    }

    public void SwapColor(SwapIndex index, Color color)
    {
        mSpriteColors[(int)index] = color;
        mColorSwapTex.SetPixel((int)index, 0, color);
    }

    private void Start()
    {
        InitColorSwapTex();
        SwapColor(SwapIndex.SkinPrim, new Color(45f, 45f, 45f));
        //SwapColor(SwapIndex.SkinSec, Color.green);
        //SwapColor(SwapIndex.ShirtPrim, Color.green);
        //SwapColor(SwapIndex.ShirtSec, Color.green);
        SwapColor(SwapIndex.Pants, Color.green);
        mColorSwapTex.Apply();

    }
}
