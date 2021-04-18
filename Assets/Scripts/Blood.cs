using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public Transform mauricius;
    public float time;
    public TrailRenderer trail;
    public SpriteRenderer sprite;
    Color[] colors = { Color.red, Color.gray, new Color(0, 0, 0, 0) };

    float timer = 0;

    Vector3 posIni;

    private void Start()
    {
        sprite.color = colors[GameManager.GetInstance().getLevel()];
        trail.startColor = colors[GameManager.GetInstance().getLevel()];
        trail.endColor = colors[GameManager.GetInstance().getLevel()];
        posIni = transform.position;
        Invoke("DestroyBlood", time);
    }

    void Update()
    {
        timer += Time.deltaTime;
        Vector3 p = Vector3.Lerp(posIni, mauricius.transform.position, timer / time);
        
        transform.position = p;
    }

    private void DestroyBlood()
    {
        Destroy(gameObject);
    }
}
