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

    [SerializeField] AudioSource bgmSource;
    public AudioSource BgmSource => bgmSource;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 100);
        bgmSource = this.GetComponent<AudioSource>();
        bgmSource.loop = true;
        if (PlayerPrefs.GetInt("BGM", 1) == 1)
        {
            bgmSource.Play();
        }
        
    }

    private void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", -80 + volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
    
   

    public void PlaySFX(AudioClip clip)
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 0)
        {
            Debug.Log("SFX is turned off.");
            return;
        }

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
