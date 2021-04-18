using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{

    public float intervaloX, intervaloY, intervaloXB, intervaloYB;
    public float minTime, maxTime, timeBattle;
    public float timeDying;

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
    bool dead = false;
    

    void Start()
    {
        ini = new Vector2(transform.position.x, transform.parent.position.y);
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        float x = transform.parent.position.x;
        float y = transform.parent.position.y;
        fin = new Vector2(Random.Range(x - intervaloX, x + intervaloX), Random.Range(y - intervaloY, y + intervaloY));
        NewPosition();
        NewTime();        
    }

    void Update()
    {
        if (dead) return;
        sprite.sortingOrder = (int)Mathf.Round(-transform.position.y * 100);
        
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
        else if (GameManager.GetInstance().GetPhase() > Phase.ADVANCE)
        {
            NewTime();
            x = transform.parent.position.x;
            y = transform.parent.position.y;
            fin = new Vector2(Random.Range(x + intervaloX, x + 2 * intervaloX), Random.Range(y - intervaloY, y + intervaloY));
        }
        else if(GameManager.GetInstance().GetPhase() == Phase.PLAYER)
        {
            time = timeBattle;
            x = battlePosition.position.x;
            y = battlePosition.position.y;
            fin = new Vector2(Random.Range(x - intervaloXB, x + intervaloXB), Random.Range(y - intervaloYB, y + intervaloYB));
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
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            lastAltitude = transform.position.y;
            rb.velocity = new Vector2(0,0);
            rb.AddForce(new Vector2(0,3), ForceMode2D.Impulse);
            jumpin = true;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(0, 0);
            lastAltitude = transform.position.y;
            rb.AddForce(new Vector2(-3, 1), ForceMode2D.Impulse);
            lastXPos = transform.position.x;
            sideForce = true;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(0, 0);
            lastAltitude = transform.position.y;
            rb.AddForce(new Vector2(3, 1), ForceMode2D.Impulse);
            lastXPos = transform.position.x;
            sideForce = true;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            animActive = true;
            animator.SetBool("Abajo", true);
        }
    }

    public void SetVaribles(MoveAround copy)
    {
        copy.intervaloX = intervaloX;
        copy.intervaloY = intervaloY;
        copy.intervaloXB = intervaloXB;
        copy.intervaloYB = intervaloYB;
        copy.minTime = minTime;
        copy.maxTime = maxTime;
        copy.timeBattle = timeBattle;
        copy.totalAnimTime = totalAnimTime;
    }

    public void Kill()
    {
        dead = true;
        rb.velocity = Vector3.zero;
        GetComponent<Animator>().SetTrigger("Dead");
        Invoke("DestroyGameObject", timeDying);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
