using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    public Text txt;

    void Start()
    {
        txt.text = "High Score: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("bestScore", 0)).ToString("D8");
    }
}
