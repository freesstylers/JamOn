using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{

    public float intervaloX, intervaloY;
    public float minTime, maxTime;

    bool jumpin = false;
    bool sideForce = false;
    bool animActive = false;

    float lastXPos;
    float lastAltitude;
    float time;
    float actualTime = 0;

    float animTime;
    public float totalAnimTime;
    Transform battlePosition;
    
    Vector2 fin;
    Vector2 ini;
    SpriteRenderer sprite;
    Animator animator;
    Rigidbody2D rb;

    Phase myPhase;
    

    void Start()
    {
        ini = new Vector2(transform.position.x, transform.parent.position.y);
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        NewPosition();
        NewTime();
    }

    void Update()
    {
        
        sprite.sortingOrder = (int)(-transform.position.y * 10);
        
        if (!jumpin && !sideForce)
        {
            MoveMinionsWithKey();
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
        if (animActive)
        {
            animTime += Time.deltaTime;
            if(animTime >= totalAnimTime)
            {
                animActive = false;
                animTime = 0;
                animator.SetBool("Abajo", false);

            }
        }
        
        if (actualTime >= time || myPhase != GameManager.GetInstance().GetPhase())
        {
            actualTime = 0;
            ini = actualTime >= time ? new Vector2(fin.x, fin.y) : new Vector2(transform.position.x, transform.position.y);
            NewPosition();            
        }

        //if (myPhase != GameManager.GetInstance().GetPhase())
        //{
        //    ini = new Vector2(transform.position.x, transform.position.y);
        //    actualTime = 0;
        //    NewPosition();
        //}
    }

    void NewPosition()
    {
        float x = 0;
        float y = 0;
        myPhase = GameManager.GetInstance().GetPhase();
        if (GameManager.GetInstance().GetPhase() == Phase.ADVANCE)
        {
            NewTime();
            x = transform.parent.position.x;
            y = transform.parent.position.y;
            fin = new Vector2(Random.Range(x - intervaloX, x + intervaloX), Random.Range(y - intervaloY, y + intervaloY));
        }
        else if(GameManager.GetInstance().GetPhase() == Phase.BATTLE)
        {
            NewTime();
            x = battlePosition.position.x;
            y = battlePosition.position.y;
            fin = new Vector2(Random.Range(x - 1, x + 1), Random.Range(y - intervaloY, y + intervaloY));
        }
    }

    void NewTime()
    {
        time = Random.Range(minTime, maxTime);
    }

    public void setBattlePosition (Transform pos)
    {
        battlePosition = pos;
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            animActive = true;
            animator.SetBool("Abajo", true);
        }
    }
}
