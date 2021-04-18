using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public float bpm;
    private float _actualTime;
    private float _timer;

    public Sprite[] sprites;
    public SpriteRenderer metronome;
    private Vector3 pointA;
    private Vector3 pointB;

    public Animator[] animators;

    // Start is called before the first frame update
    void Start()
    {
        bpm = GameManager.GetInstance().getBPM(GameManager.GetInstance().getLevel());
        _actualTime = (bpm / 60);
        pointA = transform.localEulerAngles + new Vector3(0f, 0f, 60f);
        pointB = transform.localEulerAngles + new Vector3(0f, 0f, -60f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().paused) return;

        bpm = GameManager.GetInstance().getBPM(GameManager.GetInstance().getLevel());
        _timer += Time.deltaTime;
        _actualTime = (bpm / 60);
        if((1 / _actualTime) - _timer <= 0.1f)
        {
            metronome.sprite = sprites[1];
        }
        if (_timer >= (1 / _actualTime))
        {
            GetComponent<AudioSource>().Play();
            //Debug.Log("Sound");
            _timer = 0f;
            metronome.sprite = sprites[0];

            foreach (Animator a in animators)
                a.SetTrigger("Beat");
        }
        float time = Mathf.PingPong(Time.time * _actualTime, 1);
        transform.localEulerAngles = Vector3.Lerp(pointA, pointB, time);
    }
}
