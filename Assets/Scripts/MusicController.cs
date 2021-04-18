using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip[] songs_;

    AudioSource audio_;
    void Start()
    {
        audio_ = GetComponent<AudioSource>();
        audio_.clip = songs_[GameManager.GetInstance().getLevel()];
        audio_.Play();
    }

    private void Update()
    {
        if(GameManager.GetInstance().GetLose() && audio_.isPlaying)
        {
            audio_.Stop();
        }
    }
}
