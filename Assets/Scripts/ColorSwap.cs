using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour
{

    public void Random()
    {
        if(GameManager.GetInstance().getDiscoMode())
            GameManager.GetInstance().RandomizeSprites();
    }
}
