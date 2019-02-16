using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_LoadLevel : MonoBehaviour {

    public Animator LevelLoader;
    private AudioSource source;
    public AudioClip Click;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void SceneTransition()
    {
        PlaySound();
        LoadScene(1);
    }

    public void PlaySound()
    {
        source.PlayOneShot(Click);
    }

    public void LoadScene(int levelIndex)
    {
        
        LevelLoader.SetTrigger("FadeOut");

        StartCoroutine("OnFadeComplete");
    }

    IEnumerator OnFadeComplete()
    {
        yield return new WaitForSeconds(1);
        int c = SceneManager.GetActiveScene().buildIndex;
        if (c < SceneManager.sceneCountInBuildSettings)
        SceneManager.LoadScene(c + 1);
        
    }
}
