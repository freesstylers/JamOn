using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeGameManager : MonoBehaviour
{
    private void Awake()
    {
        GameManager.GetInstance();
    }
}
