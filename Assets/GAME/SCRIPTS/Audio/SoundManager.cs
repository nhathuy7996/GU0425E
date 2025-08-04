using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    
    [SerializeField] AudioSource sfxsSourcePrefab;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        audioMixer.SetFloat("Volume", -80 + volumeSlider.value);
    }

    private void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", -80 + volume);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("Attempted to play a null audio clip.");
            return;
        }

        AudioSource sfxsSource = LazyPooling.Instant.getObjType(sfxsSourcePrefab);
        sfxsSource.gameObject.SetActive(true); 
        sfxsSource.PlayOneShot(clip);
           
         
    }
}
