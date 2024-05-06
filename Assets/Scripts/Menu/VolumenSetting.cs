using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumenSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Button muteButton;
    private bool isMuted = false;

    private void Start()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
    }
    public void SetMasterVolumen()
    {
        float volumen = MasterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volumen) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volumen);
    }
    public void SetMusicVolumen()
    {
        float volumen = MusicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volumen) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volumen);
    }
    public void SetSFXVolumen()
    {
        float volumen = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volumen) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volumen);
    }
    public void ToggleMute()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            audioMixer.SetFloat("Master", -80);
        }
        else
        {
            float volume = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
            audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        }
    }
}
