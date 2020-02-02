using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainAudioVolume : MonoBehaviour
{
    public AudioSource music, holeCreated, waterStream, ductTape, win, lose, alert;
    void Start()
    {
        music.volume = (PlayerPrefs.GetFloat("SliderVolumeLevel", 0.5f) - 0.2f) ;
        holeCreated.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", 0.5f);
        waterStream.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", 0.5f);
        ductTape.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", 0.5f);
        win.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", 0.5f);
        lose.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", 0.5f);
        alert.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", 0.5f);

        music.loop = true;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
