using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{

    public float intervaloX, intervaloY;
    public float minTime, maxTime;

    bool jumpin = false;
    bool sideForce = false;

    float lastXPos;
    float lastAltitude;
    float time;
    float actualTime = 0;
    
    Vector2 fin;
    Vector2 ini;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    

    void Start()
    {
        ini = new Vector2(transform.position.x, transform.parent.position.y);
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        NewPosition();
    }

    void Update()
    {
        
        if (!jumpin && !sideForce)
        {
            MoveMinionsWithKey();
            sprite.sortingOrder = (int)(-transform.position.y * 10);
            actualTime += Time.deltaTime;
            transform.position = Vector2.Lerp(ini, fin, actualTime / time);
        }
        else if (sideForce && transform.position.y <= lastAltitude)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            ini = new Vector2(transform.position.x, transform.position.y);
            fin = new Vector2(lastXPos, transform.position.y);
            actualTime = 0;
            NewPosition();
            lastAltitude = transform.position.y;
            lastXPos = transform.position.x;
            sideForce = false;
        }
        else if(jumpin && transform.position.y <= lastAltitude)
        { 
            rb.bodyType = RigidbodyType2D.Kinematic;
            lastAltitude = transform.position.y;
            jumpin = false;
 
        }
        
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

    void MoveMinionsWithKey()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            lastAltitude = transform.position.y;
            rb.velocity = new Vector2(0,0);
            rb.AddForce(new Vector2(0,3), ForceMode2D.Impulse);
            jumpin = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(0, 0);
            lastAltitude = transform.position.y;
            rb.AddForce(new Vector2(-3, 1), ForceMode2D.Impulse);
            lastXPos = transform.position.x;
            sideForce = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(0, 0);
            lastAltitude = transform.position.y;
            rb.AddForce(new Vector2(3, 1), ForceMode2D.Impulse);
            lastXPos = transform.position.x;
            sideForce = true;
        }
    }
}
