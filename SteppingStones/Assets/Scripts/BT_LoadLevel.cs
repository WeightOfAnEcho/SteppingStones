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

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void SceneTransition()
    {
        PlaySound();

        LoadScene(1);

    }

    public void MechanicsScene()
    {
       PlaySound();

       SceneManager.LoadScene(3);
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


    public void LevelSelect()
    {
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
            print("LEVEL SLECTOR GAMEOBJECT REQUIRED");
        }
    }

    IEnumerator WaitFor(int seconds) // delay coroutine for number of seconds delay
    {
        yield return new WaitForSeconds(seconds);
        ActivePanel();
    }
}
