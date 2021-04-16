using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MauricioSing : MonoBehaviour
{
    public Mauriçio manager;
    public Animator anim;
    public AudioClip[] vowels;

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
            int rnd = Random.Range(0, 4);
            src.clip = vowels[vocal];
            src.Play();
        }
    }

}
