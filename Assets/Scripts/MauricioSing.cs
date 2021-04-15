using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MauricioSing : MonoBehaviour
{
    public Mauriçio manager;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("Vocal", manager.getVocal());
    }
}
