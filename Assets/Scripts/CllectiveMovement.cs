using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CllectiveMovement : MonoBehaviour
{
    [Tooltip("Numero de esclavos con el que se empieza")]
    public int inicio;
    [Tooltip("Esbirro que se spawnea en el colectivo")]
    public GameObject esbirro;
    public int hp = 3;

    List<GameObject> colectivo = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < inicio; i++)
        {
            GameObject obj = Instantiate(esbirro, transform);
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
}
