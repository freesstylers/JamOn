using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayTransition : SimpleTransition
{
    public float fadeTime = 2.0f;

    float t = 0.0f;

    public Image[] buttons;

    public Transform throne;
    public Transform cultist1;

    enum AnimState { NONE, FADING, KNOCK, WAKE, OPENDOOR, COMEIN, THRONEUP, COMEOUT, END };

    AnimState state = AnimState.NONE;

    public void Go()
    {
        if (buttons.Length > 0) state++;

        foreach (Image i in buttons)
            i.gameObject.GetComponent<Button>().interactable = false;

        t = 0;
        //SceneManager.LoadSceneAsync(scene);
    }

    private void Update()
    {
        switch(state)
        {
            case AnimState.FADING:
                FadeOut(); break;

            case AnimState.END:
                LoadScene();
                break;

            default: break;
        }
        if (state == AnimState.FADING) FadeOut();
    }

    void FadeOut()
    {
        t += Time.deltaTime;

        Color c = new Color(1, 1, 1, (1 - (t / fadeTime)));

        foreach (Image i in buttons)
            i.color = c;

        if (t >= fadeTime)
        {
            state++;
            t = 0;
        }
    }
}
