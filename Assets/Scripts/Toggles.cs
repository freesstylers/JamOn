using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggles : MonoBehaviour
{

    public enum ToggleTypes { FULLSCREEN, CATMODE, DISCOMODE };

    public ToggleTypes type;

    public Toggle toggle;

    public AudioSource miau;
    public AudioSource blub;

    private void Start()
    {
        if (!toggle) return;

        switch(type)
        {
            default: break;

            case ToggleTypes.FULLSCREEN:
                toggle.isOn = Screen.fullScreen;
                break;

            case ToggleTypes.CATMODE:
                toggle.isOn = GameManager.GetInstance().getMiauMode();
                break;

            case ToggleTypes.DISCOMODE:

                break;
        }
    }

    public void Toggle(bool isOn)
    {
        if (!toggle) return;

        switch (type)
        {
            default: break;

            case ToggleTypes.FULLSCREEN:
                Screen.fullScreen = isOn;
                break;

            case ToggleTypes.CATMODE:
                GameManager gm = GameManager.GetInstance();
                gm.setMiauMode(isOn);
                if (isOn && miau) miau.Play();
                else if(!isOn && blub) blub.Play();
                break;

            case ToggleTypes.DISCOMODE:

                break;
        }
    }

}
