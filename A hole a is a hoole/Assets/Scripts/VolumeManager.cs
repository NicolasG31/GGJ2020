using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider VolumeSlider;
    public AudioSource Buttons, Music;

    private void Update()
    {
        Music.volume = VolumeSlider.value / VolumeSlider.maxValue;
        Buttons.volume = VolumeSlider.value / VolumeSlider.maxValue;
        PlayerPrefs.SetFloat("SliderVolumeLevel", Music.volume);
        PlayerPrefs.SetFloat("SliderVolumeLevel", Buttons.volume);
    }
}
