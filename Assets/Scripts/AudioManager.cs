using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] minionDeath;
    public AudioClip[] minionScream;

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

        if (Input.GetKeyDown(KeyCode.W))
        {
            source.clip = minionScream[0];
            source.Play();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            source.clip = minionScream[1];
            source.Play();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            source.clip = minionScream[2];
            source.Play();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            source.clip = minionScream[3];
            source.Play();
        }

        else if (timeElapsed >= time)
        {
            timeElapsed = 0;
        }
    }

    void SelectRandomDeathClip()
    {
        source.clip = minionDeath[Random.Range(0, minionDeath.Length)];
    }

    void SelectRandomTime()
    {
        time = Random.Range(5, 20);
    }
}
