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

        dropdownMenu.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[dropdownMenu.value].width, resolutions[dropdownMenu.value].height, false); });

        Resolution currentRes = Screen.currentResolution;
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