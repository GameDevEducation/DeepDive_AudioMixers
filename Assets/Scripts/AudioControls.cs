using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControls : MonoBehaviour
{
    [SerializeField] AudioMixer TargetMixer;

    [SerializeField] Text OverallVolumeLabel;
    [SerializeField] Slider OverallVolume;

    [SerializeField] Text SFXVolumeLabel;
    [SerializeField] Slider SFXVolume;

    [SerializeField] Text MusicVolumeLabel;
    [SerializeField] Slider MusicVolume;

    const float AudioVolumeUIOffset = 80f;

    // Start is called before the first frame update
    void Start()
    {
        float volumeValue;
        if (TargetMixer.GetFloat("OverallVolume", out volumeValue))
            OverallVolume.value = volumeValue;
        if (TargetMixer.GetFloat("SFXVolume", out volumeValue))
            SFXVolume.value = volumeValue;
        if (TargetMixer.GetFloat("MusicVolume", out volumeValue))
            MusicVolume.value = volumeValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOverallVolumeChanged(float newValue)
    {
        OverallVolumeLabel.text = "Overall Volume [" + (AudioVolumeUIOffset + newValue).ToString("0") + "]";
        TargetMixer.SetFloat("OverallVolume", newValue);
    }

    public void OnSFXVolumeChanged(float newValue)
    {
        SFXVolumeLabel.text = "Sound Effect Volume [" + (AudioVolumeUIOffset + newValue).ToString("0") + "]";
        TargetMixer.SetFloat("SFXVolume", newValue);
    }

    public void OnMusicVolumeChanged(float newValue)
    {
        MusicVolumeLabel.text = "Music Volume [" + (AudioVolumeUIOffset + newValue).ToString("0") + "]";
        TargetMixer.SetFloat("MusicVolume", newValue);
    }
}
