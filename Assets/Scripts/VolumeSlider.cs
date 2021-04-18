using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource audio;
    public string mixerVar;
    public Slider slider;

    void Start()
    {
        if(slider)
            slider.value = PlayerPrefs.GetFloat(mixerVar, 0.75f);
    }

    public void SetLevel(float sliderValue)
    {
        if (mixer)
            mixer.SetFloat(mixerVar, Mathf.Log10(sliderValue) * 20);

        PlayerPrefs.SetFloat(mixerVar, sliderValue);
        PlayerPrefs.Save();

        float pog = PlayerPrefs.GetFloat(mixerVar);

        pog++;
    }

    public void Noise()
    {
        if (audio)
            audio.Play();
    }
}
