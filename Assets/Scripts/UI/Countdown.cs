using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public GameObject one, two, three;
    public GameObject panel;

    private void OnEnable()
    {
        one.transform.localScale = Vector3.zero;
        two.transform.localScale = Vector3.zero;
        three.transform.localScale = Vector3.zero;

        LeanTween.scale(three, new Vector3(1f, 1f, 1), 0.4f).setOnComplete(ResetThree);      
    }

    void ScaleTwo()
    {
        LeanTween.scale(two, new Vector3(1f, 1f, 1), 0.4f).setOnComplete(ResetTwo);       
    }

    void ScaleOne()
    {
        LeanTween.scale(one, new Vector3(1f, 1f, 1), 0.4f).setOnComplete(ResetOne);
    }

    void ResetOne()
    {
        LeanTween.scale(one, new Vector3(0f, 0f, 1), 0.1f).setDelay(0.4f).setOnComplete(ContinueGame);
    }
    void ResetTwo()
    {
        LeanTween.scale(two, new Vector3(0f, 0f, 1), 0.1f).setDelay(0.4f).setOnComplete(ScaleOne);
    }
    void ResetThree()
    {
        LeanTween.scale(three, new Vector3(0f, 0f, 1), 0.1f).setDelay(0.4f).setOnComplete(ScaleTwo);
    }

    void ContinueGame()
    {
        gameObject.SetActive(false);
        if (panel != null ) panel.SetActive(false);

        GameManager.GetInstance().Pause();
    }
}
