using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceChild : MonoBehaviour
{
    AudioSource audioSource;
    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        StartCoroutine(waitPlayDone());
    }

    IEnumerator waitPlayDone()
    {
        yield return new WaitUntil(() => this.audioSource.isPlaying);
        yield return new WaitUntil(() => !this.audioSource.isPlaying);
        this.gameObject.SetActive(false);
    }
}
