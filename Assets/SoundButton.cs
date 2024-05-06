using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SoundButton : MonoBehaviour
{
    public AudioMixer audioMixer;
    private bool isMuted = false; 
    
    public void ToggleSound()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            audioMixer.SetFloat("Master", -80); 
        }
        else
        {
            audioMixer.SetFloat("Master", 0); 
        }
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ToggleSound);
    }
}
