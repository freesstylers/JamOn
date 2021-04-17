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

    bool isStarting = true;

    private void Start()
    {
        if (!toggle) return;

        switch(type)
        {
            default: break;

            case ToggleTypes.FULLSCREEN:
                toggle.isOn = PlayerPrefs.GetInt("FullScreen", Screen.fullScreen ? 1 : 0) == 1;
                break;

            case ToggleTypes.CATMODE:
                toggle.isOn = GameManager.GetInstance().getMiauMode();
                break;

            case ToggleTypes.DISCOMODE:
                toggle.isOn = GameManager.GetInstance().getDiscoMode();
                break;
        }

        isStarting = false;
    }

    public void Toggle(bool isOn)
    {
        if (!toggle) return;

        GameManager gm = GameManager.GetInstance();

        switch (type)
        {
            default: break;

            case ToggleTypes.FULLSCREEN:
                Screen.fullScreen = isOn;
                PlayerPrefs.SetInt("FullScreen", isOn ? 1 : 0);
                PlayerPrefs.Save();
                break;

            case ToggleTypes.CATMODE:
                gm.setMiauMode(isOn);
                if (!isStarting && isOn && miau) miau.Play();
                else if(!isStarting && !isOn && blub) blub.Play();
                break;

            case ToggleTypes.DISCOMODE:
                gm.setDiscoMode(isOn);
                break;
        }
    }

}
