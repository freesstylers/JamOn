﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPause : MonoBehaviour
{
    [SerializeField] GameObject elPutoPanel;

    // Update is called once per frame
    void Update()
    {       
        if (!GameManager.GetInstance().paused && Input.GetKeyDown(KeyCode.Escape))
        {
            elPutoPanel.SetActive(true);

            GameManager.GetInstance().Pause();
        }     
    }
}
