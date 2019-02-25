using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_Mechanic_Manager : MonoBehaviour
{


 public void LoadNext()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mechanics2"))
        {
            SceneManager.LoadScene("Mechanics3", 0);
        }

        else
        {
            SceneManager.LoadScene("Mechanics2", 0); //load the next mechanics scene
        }

    }

    public void Repeat()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name, 0); // reload current scene
    }

    public void MenuReturn()
    {
        SceneManager.LoadScene("Menu", 0); //return to main menu
    }

    public void LoadPrevious()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mechanics3"))
        {
            SceneManager.LoadScene("Mechanics2", 0);
        }

        else
        {
            SceneManager.LoadScene("Mechanics", 0); // load the first mechanics scene
        }

    }
}
