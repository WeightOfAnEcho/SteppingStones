using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_Restart_Prototype : MonoBehaviour {


    public Animator LevelLoader;
    private int levelToLoad;
    private AudioSource source;
    public AudioClip Click;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        print("xxx " + collision.collider.name);
        PlaySound();
        LoadScene(0);
    }

    public void PlaySound()
    {
        source.PlayOneShot(Click);
    }

    public void LoadScene(int levelIndex)
    {
        levelToLoad = levelIndex;
        LevelLoader.SetTrigger("FadeOut");

        StartCoroutine("OnFadeComplete");
    }

    IEnumerator OnFadeComplete()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelToLoad);
    }
}
