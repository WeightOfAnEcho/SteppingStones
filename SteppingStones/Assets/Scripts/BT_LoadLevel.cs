using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BT_LoadLevel : MonoBehaviour {

    public Animator LevelLoader;
    private AudioSource source;
    public AudioClip Click;
    public Scene thisScene;
    public GameObject selectLevel;

    public int levelIndex;

    public MusicFader fadeOut;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void QuitGame()
    {
       PlaySound();
       Application.Quit();

    }

    public void PlaySound()
    {
        print("click");
        source.PlayOneShot(Click);
    }

    public void LoadScene()
    {
        PlaySound();
        StartCoroutine("OnFadeComplete");
        LevelLoader.SetTrigger("FadeOut");
        fadeOut.EndLevel();
    }

    IEnumerator OnFadeComplete()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }



    public void LevelSelect()
    {
        PlaySound();
        LevelLoader.SetTrigger("FadeOut");
        StartCoroutine("WaitFor", 1); // Start coroutine for delay - requires int value to be passed
        LevelLoader.SetTrigger("FadeIn");
        
    }

    void ActivePanel()
    {
        if (selectLevel != null)
        {


            if (selectLevel.activeInHierarchy == false)
            {
                selectLevel.SetActive(true);
            }

            else
            {
                selectLevel.SetActive(false);
            }
        }

        else
        {
            print("LEVEL SELECTOR GAMEOBJECT REQUIRED");
        }
    }

    IEnumerator WaitFor(int seconds) // delay coroutine for number of seconds delay
    {
        yield return new WaitForSeconds(seconds);
        ActivePanel();
    }
}
