using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public float bpm;
    private float _actualTime;
    private float _timer;

    private Vector3 pointA;
    private Vector3 pointB;


    // Start is called before the first frame update
    void Start()
    {
        _actualTime = (bpm / 60);
        pointA = transform.localEulerAngles + new Vector3(0f, 0f, 60f);
        pointB = transform.localEulerAngles + new Vector3(0f, 0f, -60f);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _actualTime = (bpm / 60);
        if (_timer >= (1 / _actualTime))
        {
            //GetComponent<AudioSource>().Play();
            //Debug.Log("Sound");
            _timer = 0f;
        }
        float time = Mathf.PingPong(Time.time * _actualTime, 1);
        transform.localEulerAngles = Vector3.Lerp(pointA, pointB, time);
    }
}
