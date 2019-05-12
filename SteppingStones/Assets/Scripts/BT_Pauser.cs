using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BT_Pauser : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public AudioSource audioSource;
    //public GameObject playerCharacter;

    public Image muteImage;
    public Sprite muteSprite;
    public Sprite unmuteSprite;


    public GameObject freeButton;
    public GameObject ascendButton;

    public bool badEnding;
    

    //for tutorial
    public BT_Tutorial_Player tutorialPlayer;

    public void Start()
    {

        if (AudioListener.volume == 0f)
        {
            
            muteImage.sprite = muteSprite;
        }

        else if (AudioListener.volume == 1f)
        {
            muteImage.sprite = unmuteSprite;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("AW_Summit_#2"))
        {
            if (PlayerPrefs.HasKey("EngBatch01") && PlayerPrefs.HasKey("EngBatch02") & PlayerPrefs.HasKey("EngBatch03") && PlayerPrefs.HasKey("EngBatch04")
            && PlayerPrefs.HasKey("EngBatch05") && PlayerPrefs.HasKey("EngBatch06")) // if you have the full english text unlocked (positive ending)
            {
                freeButton.SetActive(true);
                ascendButton.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_0"))
        {
            tutorialPlayer.hadTutorialPause = true;
            StartCoroutine(tutorialPlayer.FadeTextToZeroAlpha(1f, tutorialPlayer.tutorialPause));
            tutorialPlayer.tutorialPauseParticle.Stop();
        }

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

    public void Muter()
    {
        if (AudioListener.volume == 1f)
        {
            AudioListener.volume = 0f;
            muteImage.sprite = muteSprite;
        }

        else
        {
            AudioListener.volume = 1f;
            muteImage.sprite = unmuteSprite;
        }
       
    }

    public void BadEnding()
    {
        badEnding = true;
        Resume();

    }

    public void GoodEnding()
    {
        badEnding = false;
        Resume();
    }
}
