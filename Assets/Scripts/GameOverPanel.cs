using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{

    private void Start()
    {
        Color aux = GetComponent<SpriteRenderer>().color;
        aux.a = 0.0f;
        GetComponent<SpriteRenderer>().color = aux;
    }

    void Update()
    {
        if(GameManager.GetInstance().GetLose())
        {
            Color aux = GetComponent<SpriteRenderer>().color;
            if (aux.a < 1.0f)
            {
                aux.a += 0.1f * Time.deltaTime;
                GetComponent<SpriteRenderer>().color = aux;
            }
        }
    }
}
