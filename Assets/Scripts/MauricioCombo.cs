using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MauricioCombo : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anim;   

    public Text text;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().GetCombo() >= 10)
        {
            anim.SetBool("Combo10", true);
        }
        else
        {
            anim.SetBool("Combo10", false);
        }

        text.text = ("x" + (GameManager.GetInstance().GetCombo()).ToString());
    }
}
