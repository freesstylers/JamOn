using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAnim : MonoBehaviour
{

    public LeanTweenType easyType;
    public GameObject countDown;

    void Start()
    {
        transform.localScale = Vector3.zero;

        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1), 1f).setEase(easyType).setDelay(0.3f);
        LeanTween.rotate(gameObject, new Vector3(0, 0, 720), 1.4f).setEase(easyType).setDelay(0.3f);
    }

    public void Resume()
    {
        LeanTween.scale(gameObject, new Vector3(0f, 0f, 1), 0.3f).setOnComplete(ResumeEnd);
    }

    public void ResumeEnd()
    {
        countDown.SetActive(true);
    }
    
}
