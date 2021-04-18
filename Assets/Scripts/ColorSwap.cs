using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour
{

    public void Random()
    {
        GameManager.GetInstance().RandomizeSprites();
    }
}
