using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    List<KeyCode> keys = new List<KeyCode>{ KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };
    public int key_;

    public Mauriçio mauriçio_;

    void Update()
    {
        if(Input.GetKeyDown(keys[key_])) {
            Destroy(gameObject);
            //mauriçio_.PressedKey();
        }
    }
}
