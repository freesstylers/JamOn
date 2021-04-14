using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleppeScript : MonoBehaviour
{
    public Animator anim;

    [Range(0.0f, 1.0f)]
    public float speed;

    public int startFrame;
    public int maxFrames = 4;

    // Start is called before the first frame update
    void Start()
    {
        anim.speed = speed;

        startFrame = startFrame % maxFrames;

        anim.Play("sleppe", 0, (float)startFrame / (float)maxFrames);
    }
}
