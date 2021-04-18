using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MauricioSing : MonoBehaviour
{
    public Mauriçio manager;
    public Animator anim;
    public AudioClip[] vowelsA;
    public AudioClip[] vowelsO;
    public AudioClip[] vowelsE;
    public AudioClip[] vowelsI;
    public AudioClip[] miaus;

    AudioSource src;
    private void Start()
    {
        src = GetComponent<AudioSource>();
        if (src == null)
            Debug.Log("No tengo AudioSource");
    }

    // Update is called once per frame
    void Sing(int vocal)
    {
        anim.SetInteger("Vocal", vocal);
        if (vocal != -1)
        {
            if (GameManager.GetInstance().getMiauMode())
            {
                int rnd = Random.Range(0, miaus.Length);
                src.clip = miaus[rnd];
                src.Play();
            }
            else
            {
                AudioClip[][] vowels = { vowelsA, vowelsO, vowelsE, vowelsI };
                int rnd = Random.Range(0, 3);
                src.clip = vowels[vocal][rnd];
                src.Play();
            }
        }
    }

}
