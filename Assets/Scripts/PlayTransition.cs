using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayTransition : SimpleTransition
{
    public float fadeTime = 2.0f;
    public float moveTime = 2.0f;
    public float jumpTime = 2.0f;

    int jumpDir = 1;

    float t = 0.0f;

    public Text[] textToFade;
    public Image[] buttonsToFade;
    public Image[] imagesToFade;

    public Transform throne;
    public sleppeScript cultist1;
    public sleppeScript cultist2;

    public Transform marabunta;
    public Vector3 marabuntaInit;
    public Vector3 marabuntaEnd;

    public float originalHeight;
    public float jumpHeight;
    public float heightAfterJump;

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

                cultist1.WakeUp();
                cultist2.WakeUp();

                state++;
                break;

            case AnimState.WAKE:
                if (!knock.isPlaying && !cultist1.IsPlaying() && !cultist2.IsPlaying())
                {
                    cultist1.Jump();
                    cultist2.Jump();

                    wake.Play();

                    state++;
                }
                break;

            case AnimState.OPENDOOR:
                if (!wake.isPlaying)
                {
                    open.Play();
                }

                if (!open.isPlaying)
                {
                    walkk.Play();
                    t = 0;
                    state++;
                }
                break;

            case AnimState.COMEIN:

                if (t < moveTime)
                {
                    marabunta.localPosition = Vector3.Lerp(marabuntaInit, marabuntaEnd, t / moveTime);
                    t += Time.deltaTime;
                }
                else
                {
                    state++;
                    GameObject.Destroy(cultist1.gameObject);
                    GameObject.Destroy(cultist2.gameObject);

                    cultist1 = cultist2 = null;
                }

                break;

            case AnimState.THRONEUP:

                if (walkk.isPlaying)
                {
                    walkk.Stop();
                    throneup.Play();
                    marabunta.localScale = new Vector3(-marabunta.localScale.x, marabunta.localScale.y, marabunta.localScale.z);

                    throne.SetParent(marabunta);
                    t = 0;
                }

                if(t < jumpTime / 2.0f)
                {
                    if (jumpDir == 1)
                    {
                        float y = Mathf.Lerp(originalHeight, jumpHeight, t / (jumpTime / 2.0f));
                        throne.localPosition = new Vector3(throne.localPosition.x, y, throne.localPosition.z);
                    }
                    else
                    {
                        float y = Mathf.Lerp(jumpHeight, heightAfterJump, t / (jumpTime / 2.0f));
                        throne.localPosition = new Vector3(throne.localPosition.x, y, throne.localPosition.z);
                    }

                    t += Time.deltaTime;
                }
                else
                {
                    if(jumpDir == 1)
                    {
                        t = 0;
                        jumpDir = -1;

                        throne.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 200;
                    }
                    else
                    {
                        walkk.Play();
                        t = 0;
                        state++;
                    }
                }
                break;

            case AnimState.COMEOUT:
                if (t < moveTime)
                {
                    marabunta.localPosition = Vector3.Lerp(marabuntaEnd, marabuntaInit, t / moveTime);
                    t += Time.deltaTime;
                }
                else
                {
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

        foreach (Image i in imagesToFade)
            i.color = c;

        if (t >= fadeTime)
        {
            state++;
            t = 0;
        }
    }
}
