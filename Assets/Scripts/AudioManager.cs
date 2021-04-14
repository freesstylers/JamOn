using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] minion;

    float timeElapsed;
    float time;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= time)
        {
            timeElapsed = 0;
            SelectRandomClip();
            source.Play();
            SelectRandomTime();
        }
    }

    void SelectRandomClip()
    {
        source.clip = minion[Random.Range(0, minion.Length)];
    }

    void SelectRandomTime()
    {
        time = Random.Range(5, 20);
    }
}
