using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScreenResolutions : MonoBehaviour
{

    List<Resolution> resolutions = new List<Resolution>();
    public Dropdown dropdownMenu;

    void Start()
    {
        if (resolutions == null || resolutions.Count == 0)
        {
            resolutions.AddRange(Screen.resolutions.ToList().Distinct());
        }

        resolutions = resolutions.OrderByDescending(r => r.width).ToList();

        dropdownMenu.onValueChanged.AddListener(delegate {
            Screen.SetResolution(resolutions[dropdownMenu.value].width, resolutions[dropdownMenu.value].height, PlayerPrefs.GetInt("FullScreen", Screen.fullScreen ? 1 : 0) == 1, resolutions[dropdownMenu.value].refreshRate);

            PlayerPrefs.SetInt("ScreenWidth", resolutions[dropdownMenu.value].width);
            PlayerPrefs.SetInt("ScreenHeight", resolutions[dropdownMenu.value].height);
            PlayerPrefs.SetInt("ScreenRefresh", resolutions[dropdownMenu.value].refreshRate);

            PlayerPrefs.Save();
        });

        Resolution currentRes = new Resolution();

        currentRes.width = PlayerPrefs.GetInt("ScreenWidth", Screen.currentResolution.width);
        currentRes.height = PlayerPrefs.GetInt("ScreenHeight", Screen.currentResolution.height);
        currentRes.refreshRate = PlayerPrefs.GetInt("ScreenRefresh", Screen.currentResolution.refreshRate);

        int i = 0;

        foreach (Resolution r in resolutions)
        {
            dropdownMenu.options.Add(new Dropdown.OptionData(ResToString(r)));
            dropdownMenu.options[i].text = ResToString(r);

            if (currentRes.width == r.width && currentRes.height == r.height && currentRes.refreshRate == r.refreshRate)
                dropdownMenu.value = i;

            i++;
        }

        dropdownMenu.RefreshShownValue();
    }

    string ResToString(Resolution res)
    {
        return res.width + "x" + res.height + " @ " + res.refreshRate + "Hz";
    }
}