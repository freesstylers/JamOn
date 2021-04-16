using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float intervaloX, intervaloY;
    public float minTime, maxTime;
    float time;
    float actualTime = 0;

    public float totalAnimTime;
    Transform battlePosition;

    Vector2 fin;
    Vector2 ini;
    SpriteRenderer sprite;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        float x = transform.parent.position.x;
        float y = transform.parent.position.y;
        ini = new Vector2(transform.position.x, transform.parent.position.y);
        fin = new Vector2(Random.Range(x - intervaloX, x + intervaloX), Random.Range(y - intervaloY, y + intervaloY));
        time = minTime;
    }

    void Update()
    {
        sprite.sortingOrder = (int)(-transform.position.y * 10);
        transform.position = Vector2.Lerp(ini, fin, actualTime / time);

        actualTime += Time.deltaTime;

        if (actualTime >= time)
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

        if (GameManager.GetInstance().GetPhase() == Phase.BATTLE)
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

    public void setBattlePosition(Transform pos)
    {
        battlePosition = pos;
    }

    public void Kill()
    {
        //TODO: Cambiar a animacion de muerte y que pase lo que sea (Destroy)

        Destroy(gameObject);
    }
}
