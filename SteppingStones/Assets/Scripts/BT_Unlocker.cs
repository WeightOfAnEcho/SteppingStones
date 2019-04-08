using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Unlocker : MonoBehaviour
{
    public GameObject loading;

    public GameObject[] levelButtons;
    public GameObject[] lockedImages;
    public static BT_Unlocker i;


    //CURRENT LEVEL REFERENCES - THESE WILL CHANGE AS MORE LEVELS ARE ADDED

    // Level 02 - FOREST
    // Level 03 - BoM

    //Lock/level [0] = beach
    //Lock/level [1] = forest
    //Lock/level [2] = BoM
    //lock/level [3] = mountain
    //lock/level [4] = summit


    void Awake()
    {
        RefreshPrefs();
    }

    private void Update() //CHEAT CODES - MUST BE PRESSED ON MAIN MENU
    {
        if (Input.GetKeyDown(KeyCode.W)) // Unlock all Levels
        {
            PlayerPrefs.SetInt("Level00Complete", 1); // unlock the forest level
            PlayerPrefs.SetInt("Level01Complete", 1); //unlock forest
            PlayerPrefs.SetInt("Level02Complete", 1); // Unlock bom
            PlayerPrefs.SetInt("Level03Complete", 1); //unlock Mountain
            PlayerPrefs.SetInt("Level04Complete", 1); // unlock summit
            PlayerPrefs.Save();
            RefreshPrefs();
            print("Unlocking all levels");

           
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
            RefreshPrefs();
            print("clearing Prefs");
        }


    }


    void RefreshPrefs()
    {

        // IF HAS KEYS

        if (PlayerPrefs.HasKey("Level00Complete")) // if tutorial complete
        {
            levelButtons[0].SetActive(true);
            lockedImages[0].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Level01Complete")) // if beach complete
        {
            levelButtons[1].SetActive(true);
            lockedImages[1].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Level02Complete")) // if forest complete
        {
            levelButtons[2].SetActive(true);
            lockedImages[2].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Level03Complete")) // if BoM complete
        {
            levelButtons[3].SetActive(true);
            lockedImages[3].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Level04Complete")) // if mountain complete
        {
            levelButtons[4].SetActive(true);
            lockedImages[4].SetActive(false);
        }

        //If DOESN'T

        if (!PlayerPrefs.HasKey("Level00Complete"))
        {
            levelButtons[0].SetActive(false);
            lockedImages[0].SetActive(true);
        }

        if (!PlayerPrefs.HasKey("Level01Complete"))
        {
            levelButtons[1].SetActive(false);
            lockedImages[1].SetActive(true);
        }

        if (!PlayerPrefs.HasKey("Level02Complete"))
        {
            levelButtons[2].SetActive(false);
            lockedImages[2].SetActive(true);
        }

        if (!PlayerPrefs.HasKey("Level03Complete")) // if BoM complete
        {
            levelButtons[3].SetActive(false);
            lockedImages[3].SetActive(true);
        }

        if (!PlayerPrefs.HasKey("Level04Complete")) // if mountain complete
        {
            levelButtons[4].SetActive(false);
            lockedImages[4].SetActive(true);
        }

    }

    }
