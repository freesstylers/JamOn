using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAnim : MonoBehaviour
{

    public LeanTweenType easyType;

    void Start()
    {
        transform.localScale = Vector3.zero;

        LeanTween.rotate(gameObject, new Vector3(0, 0, 720), 1.4f).setEase(easyType).setDelay(0.3f);
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1), 1f).setEase(easyType).setDelay(0.3f);
    }

    
}
