using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientLangCheck : MonoBehaviour
{

    private static bool CheckerExists;
    public GameObject[] EnglishBatches;
    public GameObject[] AncientBatches;
    public static AncientLangCheck i;

    // Start is called before the first frame update
    void Awake()
    {
        RefreshPrefs();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) // Unlock all Levels
        {
            PlayerPrefs.SetInt("EngBatch01", 1); 
            PlayerPrefs.SetInt("EngBatch02", 1); 
            PlayerPrefs.SetInt("EngBatch03", 1); 
            PlayerPrefs.SetInt("EngBatch04", 1); 
            PlayerPrefs.SetInt("EngBatch05", 1);
            PlayerPrefs.SetInt("EngBatch06", 1);

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

    public void RefreshPrefs()
    {
        // IF HAS KEYS

        if (PlayerPrefs.HasKey("EngBatch01")) // if tutorial complete
        {
            AncientBatches[0].SetActive(false);
            EnglishBatches[0].SetActive(true);
        }

        if (PlayerPrefs.HasKey("EngBatch02")) // if tutorial complete
        {
            AncientBatches[1].SetActive(false);
            EnglishBatches[1].SetActive(true);
        }

        if (PlayerPrefs.HasKey("EngBatch03")) // if tutorial complete
        {
            AncientBatches[2].SetActive(false);
            EnglishBatches[2].SetActive(true);
        }

        if (PlayerPrefs.HasKey("EngBatch04")) // if tutorial complete
        {
            AncientBatches[3].SetActive(false);
            EnglishBatches[3].SetActive(true);
        }

        if (PlayerPrefs.HasKey("EngBatch05")) // if tutorial complete
        {
            AncientBatches[4].SetActive(false);
            EnglishBatches[4].SetActive(true);
        }

        if (PlayerPrefs.HasKey("EngBatch06")) // if tutorial complete
        {
            AncientBatches[5].SetActive(false);
            EnglishBatches[5].SetActive(true);
        }


        //If DOESN'T

        if (!PlayerPrefs.HasKey("EngBatch01"))
        {
            EnglishBatches[0].SetActive(false);
            AncientBatches[0].SetActive(true);
        }

        if (!PlayerPrefs.HasKey("EngBatch02"))
        {
            EnglishBatches[1].SetActive(false);
            AncientBatches[1].SetActive(true);
        }

        if (!PlayerPrefs.HasKey("EngBatch03"))
        {
            EnglishBatches[2].SetActive(false);
            AncientBatches[2].SetActive(true);
        }

        if (!PlayerPrefs.HasKey("EngBatch04"))
        {
            EnglishBatches[3].SetActive(false);
            AncientBatches[3].SetActive(true);
        }

        if (!PlayerPrefs.HasKey("EngBatch05"))
        {
            EnglishBatches[4].SetActive(false);
            AncientBatches[4].SetActive(true);
        }

        if (!PlayerPrefs.HasKey("EngBatch06"))
        {
            EnglishBatches[5].SetActive(false);
            AncientBatches[5].SetActive(true);
        }



    }
}
