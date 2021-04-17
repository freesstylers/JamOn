using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] minionDeath;
    public AudioClip[] minionScream;
    public AudioClip[] minionScreamMiau;

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

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (GameManager.GetInstance().getMiauMode())
                source.clip = minionScreamMiau[Random.Range(0, minionScreamMiau.Length)];
            else
                source.clip = minionScream[0];

            source.Play();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (GameManager.GetInstance().getMiauMode())
                source.clip = minionScreamMiau[Random.Range(0, minionScreamMiau.Length)];
            else
                source.clip = minionScream[1];
            
            source.Play();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (GameManager.GetInstance().getMiauMode())
                source.clip = minionScreamMiau[Random.Range(0, minionScreamMiau.Length)];
            else
                source.clip = minionScream[2];
            
            source.Play();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (GameManager.GetInstance().getMiauMode())
                source.clip = minionScreamMiau[Random.Range(0, minionScreamMiau.Length)];
            else
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
