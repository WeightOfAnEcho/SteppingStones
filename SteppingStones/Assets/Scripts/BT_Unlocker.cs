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

    //Lock/level [0] = Forest
    //Lock/level [1] = BoM
    //Lock/level [2] = Summit2


    void Awake()
    {
        RefreshPrefs();
    }

    private void Update() //CHEAT CODES - MUST BE PRESSED ON MAIN MENU
    {
        if (Input.GetKeyDown(KeyCode.W)) // Unlock all Levels
        {
            PlayerPrefs.SetInt("Level01Complete", 1); // unlock the forest level
            PlayerPrefs.SetInt("Level02Complete", 1); //unlock BoM level
            PlayerPrefs.SetInt("Level03Complete", 1); // Unlock Summit Level
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

        if (PlayerPrefs.HasKey("Level01Complete"))
        {
            levelButtons[0].SetActive(true);
            lockedImages[0].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Level02Complete"))
        {
            levelButtons[1].SetActive(true);
            lockedImages[1].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Level03Complete"))
        {
            levelButtons[2].SetActive(true);
            lockedImages[2].SetActive(false);
        }

        //If DOESN'T

        if (!PlayerPrefs.HasKey("Level01Complete"))
        {
            levelButtons[0].SetActive(false);
            lockedImages[0].SetActive(true);
        }

        if (!PlayerPrefs.HasKey("Level02Complete"))
        {
            levelButtons[1].SetActive(false);
            lockedImages[1].SetActive(true);
        }

        if (!PlayerPrefs.HasKey("Level03Complete"))
        {
            levelButtons[2].SetActive(false);
            lockedImages[2].SetActive(true);
        }

    }

    }
