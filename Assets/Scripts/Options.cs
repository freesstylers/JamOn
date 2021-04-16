using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Button[] buttons;
    public GameObject optionsCanvas;

    public void Toggle()
    {
        if(optionsCanvas)
            optionsCanvas.SetActive(!optionsCanvas.activeSelf);

        foreach (Button b in buttons)
            b.interactable = !b.interactable;
    }
}
