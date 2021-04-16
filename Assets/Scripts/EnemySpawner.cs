﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Numero de enemigos")]
    public int inicio;
    [Tooltip("Lugar de pelea del esbirro")]
    public Transform battlePosition;
    [Header("Seleccion de enemigo")]
    [Tooltip("Prefabs de enemigos spwneables")]
    public GameObject[] enemyPrefabs;
    [Tooltip("Enemigo a seleccionar")]
    public int enemy;

    public MinionBehaviour minionBehaviour;

    List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        //Spawn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Kill();
        }
    }

    // Puede que necesitemos un entero de entrada para controlar 
    // el enemigo que debemos spawnear y la cantidad
    public void Spawn()
    {
        for (int i = 0; i < inicio; i++)
        {
            GameObject obj = Instantiate(enemyPrefabs[enemy], transform);
            obj.GetComponent<EnemyController>().setBattlePosition(battlePosition);
            enemies.Add(obj);
        }
    }

    public void Kill()
    {
        minionBehaviour.AddMinions(5);
        int bucle = enemies.Count;
        for (int i = 0; i < bucle; i++)
        {
            GameObject obj = enemies[0];
            enemies.RemoveAt(0);
            obj.GetComponent<EnemyController>().Kill();
        }
    }
}