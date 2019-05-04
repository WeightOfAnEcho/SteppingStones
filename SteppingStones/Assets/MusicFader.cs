using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFader: MonoBehaviour
{

    public AudioSource audioSource;

    public void Awake()
    {
        GetComponent<AudioSource>();
        StartCoroutine(FadeIn(audioSource, 10f));
    }

    IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 0.2)
        {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }

    public void EndLevel()
    {
        StartCoroutine(FadeOut(audioSource, 1f));
    }

    IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
    }
}


