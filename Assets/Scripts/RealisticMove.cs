using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealisticMove : MonoBehaviour
{
    public float angInterval = 0.2f;
    Vector3 ini = new Vector3(0, 0, 0);
    Vector3 fin = new Vector3(0, 0, 0);

    float time = 0;
    int sentido = 1;

    private void Start()
    {
        fin.z = angInterval;
        ini.z = -angInterval;
    }

    private void Update()
    {
        time += sentido * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Vector3.Lerp(ini, fin, time).z);
        if (time < 0)
        {
            time = 0;
            sentido *= -1;
        } else if(time > 1)
        {
            time = 1;
            sentido *= -1;
        }
    }
}
