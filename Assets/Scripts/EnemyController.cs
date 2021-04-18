using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float intervaloX, intervaloY, intervaloXB, intervaloYB;
    public float timeSpawn, timeBattle, timeDying;
    float time;
    float actualTime = 0;

    public float totalAnimTime;
    Transform battlePosition;

    Vector2 fin;
    Vector2 ini;
    SpriteRenderer sprite;

    bool dead = false;
    Phase myPhase;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        float x = transform.parent.position.x;
        float y = transform.parent.position.y;
        ini = new Vector2(transform.position.x, transform.parent.position.y);
        fin = new Vector2(Random.Range(x - intervaloX, x + intervaloX), Random.Range(y - intervaloY, y + intervaloY));
        time = timeSpawn;
    }
    
    void Update()
    {
        if (GameManager.GetInstance().paused) return;

        if (dead) return;
        sprite.sortingOrder = (int)(-transform.position.y * 10);
        transform.position = Vector2.Lerp(ini, fin, actualTime / time);

        actualTime += Time.deltaTime;

        if (actualTime >= time || myPhase != GameManager.GetInstance().GetPhase())
        {
            actualTime = 0;
            ini = new Vector2(fin.x, fin.y);
            NewPosition();
        }
    }

    void NewPosition()
    {
        float x = 0;
        float y = 0;
        myPhase = GameManager.GetInstance().GetPhase();
        if (GameManager.GetInstance().GetPhase() == Phase.PLAYER)
        {
            time = timeBattle;
            x = battlePosition.position.x;
            y = battlePosition.position.y;
            fin = new Vector2(Random.Range(x - intervaloXB, x + intervaloXB), Random.Range(y - intervaloYB, y + intervaloYB));

            GetComponent<Animator>().SetBool("Idle", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Idle", true);
        }
    }

    public void setBattlePosition(Transform pos)
    {
        battlePosition = pos;
    }

    public void Kill()
    {
        dead = true;
        GetComponent<Animator>().SetTrigger("Dead");
        Invoke("DestroyGameObject", timeDying);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
