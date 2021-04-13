using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{

    public float intervaloX, intervaloY;
    public float minTime, maxTime;

    float time;
    float actualTime = 0;
    Vector2 fin;
    Vector2 ini;
    SpriteRenderer sprite;

    void Start()
    {
        ini = new Vector2(transform.position.x, transform.parent.position.y);
        sprite = GetComponent<SpriteRenderer>();
        NewPosition();
    }

    void Update()
    {
        sprite.sortingOrder = (int)(-transform.position.y * 10);
        actualTime += Time.deltaTime;
        transform.position = Vector2.Lerp(ini, fin, actualTime / time);
        if (actualTime >= time)
        {
            actualTime = 0;
            ini = new Vector2(fin.x, fin.y);
            NewPosition();            
        }
    }

    void NewPosition()
    {
        NewTime();
        float x = transform.parent.position.x;
        float y = transform.parent.position.y;
        fin = new Vector2(Random.Range(x - intervaloX, x + intervaloX), Random.Range(y - intervaloY, y + intervaloY));
    }

    void NewTime()
    {
        time = Random.Range(minTime, maxTime);
    }
}
