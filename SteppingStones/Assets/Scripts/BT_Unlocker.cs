using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Unlocker : MonoBehaviour
{
    public GameObject loading;

    public GameObject[] levelButtons;
    public GameObject[] lockedImages;
    public static BT_Unlocker i;

    void Awake()
    {
        if (!i)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }


    void Start()
    {
        if (PlayerPrefs.HasKey("Level01Complete"))
        {

        }

        if (PlayerPrefs.HasKey("Level02Complete"))
        {
            levelButtons[1].SetActive(true);
            lockedImages[1].SetActive(false);
        }

        if (PlayerPrefs.HasKey("Level03Complete"))
        {
           
        }

    }
}
