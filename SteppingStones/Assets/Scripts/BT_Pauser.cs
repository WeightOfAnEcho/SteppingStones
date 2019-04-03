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
    public GameObject playerCharacter;

    public Image muteImage;
    public Sprite muteSprite;
    public Sprite unmuteSprite;

    public void Start()
    {
        //muteImage = GetComponent<Image>();
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        playerCharacter.SetActive(true);
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        playerCharacter.SetActive(false);
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
        if (audioSource.mute != true)
        {
            audioSource.mute = true;
            muteImage.sprite = muteSprite;
        }

        else
        {
            audioSource.mute = false;
            muteImage.sprite = unmuteSprite;
        }
       
    }
}
