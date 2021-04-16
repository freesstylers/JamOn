﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBehaviour : MonoBehaviour
{
    [Tooltip("Numero de esclavos con el que se empieza")]
    public int inicio;
    [Tooltip("Esbirro que se spawnea en el colectivo")]
    public GameObject esbirro;
    [Tooltip("Lugar de pelea del esbirro")]
    public Transform battlePosition;
    public int hp = 3;

    List<GameObject> colectivo = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < inicio; i++)
        {
            GameObject obj = Instantiate(esbirro, transform);
            obj.GetComponent<MoveAround>().setBattlePosition(battlePosition);
            colectivo.Add(obj);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage();
        }
    }

    public void Damage()
    {
        int bucle = colectivo.Count / hp;
        for (int i = 0; i < bucle; i++)
        {
            GameObject obj = colectivo[0];
            colectivo.RemoveAt(0);
            Destroy(obj);
        }
        hp--;
    }

    public void AddMinions(int n)
    {
        for (int i = 0; i < n; i++)
        {
            GameObject obj = Instantiate(esbirro, transform);
            obj.GetComponent<MoveAround>().setBattlePosition(battlePosition);
            colectivo.Add(obj);
        }
    }

    public void AddMinions(List<GameObject> enemies)
    {
        foreach(GameObject e in enemies)
        {
            e.GetComponent<SpriteRenderer>().flipX = !e.GetComponent<SpriteRenderer>().flipX;
            e.transform.parent = gameObject.transform;
            e.AddComponent<Rigidbody2D>().isKinematic = true;
            Destroy(e.GetComponent<EnemyController>());
            MoveAround m = e.GetComponent<MoveAround>();
            colectivo[0].GetComponent<MoveAround>().SetVaribles(m);
            m.enabled = true;
            m.setBattlePosition(battlePosition);
            colectivo.Add(e);
        }
    }
}
