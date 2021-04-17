using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour
{

    [SerializeField] SpriteRenderer[] renderers;

    public Texture2D mColorSwapTex;
    Color[] mSpriteColors;


    public void InitColorSwapTex()
    {
        Texture2D colorSwapTex = new Texture2D(256, 1, TextureFormat.RGBA32, false, false);
        colorSwapTex.filterMode = FilterMode.Point;

        for (int i = 0; i < colorSwapTex.width; ++i)
            colorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));

        colorSwapTex.Apply();

        foreach (SpriteRenderer r in renderers)
        {
            if(r.material.GetTexture("_SwapTex") == null)
                r.material.SetTexture("_SwapTex", colorSwapTex);
        }

        mSpriteColors = new Color[colorSwapTex.width];
        mColorSwapTex = colorSwapTex;
    }

    public void SwapColor(int index, Color color)
    {
        mSpriteColors[index] = color;
        mColorSwapTex.SetPixel(index, 0, color);
    }

    // Start is called before the first frame update
    void Start()
    {
        Color[] colors = new Color[256];

        for(int i= 0; i< 255; i++)
        {
            colors[i] = Random.ColorHSV();
        }

        //InitColorSwapTex();
        StartCoroutine(newSprites());

        for (int i = 0; i < 255; i++)
        {
            SwapColor(i, colors[i]);
        }

        mColorSwapTex.Apply();

    }

    IEnumerator newSprites()
    {
        while (true)
        {
            renderers = FindObjectsOfType<SpriteRenderer>();
            InitColorSwapTex();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
