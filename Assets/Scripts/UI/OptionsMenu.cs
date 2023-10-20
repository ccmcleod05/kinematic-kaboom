using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    
    public void SetVolume(float volume){
        audioMixer.SetFloat("Volume", volume);
        SaveVolume(volume);
    }

    public void SaveVolume(float volume){
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void LoadVolume(){
        float volume = PlayerPrefs.GetFloat("Volume");
        SetVolume(volume);
    }
}
