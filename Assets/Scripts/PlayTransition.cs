using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayTransition : SimpleTransition
{
    public float fadeTime = 2.0f;

    float t = 0.0f;

    public Text[] textToFade;
    public Image[] buttonsToFade;

    public Transform throne;
    public Transform cultist1;

    enum AnimState { NONE, FADING, KNOCK, WAKE, OPENDOOR, COMEIN, THRONEUP, COMEOUT, END };

    AnimState state = AnimState.NONE;

    public AudioSource knock;
    public AudioSource wake;
    public AudioSource open;
    public AudioSource walkk;
    public AudioSource throneup;

    public void Go()
    {
        if (buttonsToFade.Length > 0) state++;

        foreach (Image i in buttonsToFade)
            i.gameObject.GetComponent<Button>().interactable = false;

        t = 0;
        //SceneManager.LoadSceneAsync(scene);
    }

    private void Update()
    {
        switch(state)
        {
            case AnimState.FADING:
                FadeOut();
                break;

            case AnimState.KNOCK:
                knock.Play();
                state++;
                break;

            case AnimState.WAKE:
                if(!knock.isPlaying)
                {
                    wake.Play();
                    state++;
                }
                break;

            case AnimState.OPENDOOR:
                if (!wake.isPlaying)
                {
                    open.Play();
                    state++;
                }
                break;

            case AnimState.COMEIN:
                if (!open.isPlaying)
                {
                    walkk.Play();
                    state++;
                }
                break;

            case AnimState.THRONEUP:
                if (!walkk.isPlaying)
                {
                    throneup.Play();
                    state++;
                }
                break;

            case AnimState.COMEOUT:
                if (!throneup.isPlaying)
                {
                    walkk.Play();
                    state++;
                }
                break;

            case AnimState.END:
                if (!walkk.isPlaying)
                {
                    LoadScene();
                }
                break;

            default: break;
        }
        if (state == AnimState.FADING) FadeOut();
    }

    void FadeOut()
    {
        t += Time.deltaTime;

        Color c = new Color(1, 1, 1, (1 - (t / fadeTime)));

        foreach (Image i in buttonsToFade)
            i.color = c;

        foreach (Text i in textToFade)
            i.color = c;

        if (t >= fadeTime)
        {
            state++;
            t = 0;
        }
    }
}
