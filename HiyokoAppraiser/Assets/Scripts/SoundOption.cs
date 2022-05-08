using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider VolumeSlider;

    private void Start()
    {

        audioMixer.GetFloat("MasterVol", out float bgmVolume);
        VolumeSlider.value = bgmVolume;
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("MasterVol", volume);
    }


}