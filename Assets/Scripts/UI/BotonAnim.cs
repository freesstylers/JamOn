using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAnim : MonoBehaviour
{

    public LeanTweenType easyType;
    public GameObject countDown;
    public GameObject resume;

    public RectTransform options, menu;

    public float moveOptions;

    void OnEnable()
    {
        resume.transform.localScale = Vector3.zero;

        //Resume button animation
        LeanTween.scale(resume, new Vector3(1f, 1f, 1), 1f).setEase(easyType).setDelay(0.3f);
        LeanTween.rotate(resume, new Vector3(0, 0, 720), 1.4f).setEase(easyType).setDelay(0.3f);

        //Options button animation
        LeanTween.moveY(options, moveOptions, 0.6f).setEase(easyType);

        //Menu button animation
        LeanTween.moveY(menu, moveOptions, 0.6f).setEase(easyType);
    }

    public void Resume()
    {
        //Options button animation
        LeanTween.moveY(options, -moveOptions, 0.6f).setEase(easyType);

        //Menu button animation
        LeanTween.moveY(menu, -moveOptions, 0.6f).setEase(easyType);
      
        LeanTween.scale(resume, new Vector3(0f, 0f, 1), 0.3f).setOnComplete(ResumeEnd);
    }

    public void ResumeEnd()
    {
        countDown.SetActive(true);
    }   

    public void Opsione()
    {
        //Options button animation
        LeanTween.moveY(options, -moveOptions, 0.6f).setEase(easyType);

        //Menu button animation
        LeanTween.moveY(menu, -moveOptions, 0.6f).setEase(easyType);
    }

    public void NoOpsione()
    {
        //Options button animation
        LeanTween.moveY(options, moveOptions, 0.6f).setEase(easyType);

        //Menu button animation
        LeanTween.moveY(menu, moveOptions, 0.6f).setEase(easyType);
    }
}
