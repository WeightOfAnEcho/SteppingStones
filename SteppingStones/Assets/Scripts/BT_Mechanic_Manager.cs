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
            SceneManager.LoadScene("Mechanics3");
        }

        else
        {
            SceneManager.LoadScene("Mechanics2"); //load the next mechanics scene
        }

    }

    public void Repeat()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name); // reload current scene
    }

    public void MenuReturn()
    {
        SceneManager.LoadScene("Menu"); //return to main menu
    }

    public void LoadPrevious()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mechanics3"))
        {
            SceneManager.LoadScene("Mechanics2");
        }

        else
        {
            SceneManager.LoadScene("Mechanics"); // load the first mechanics scene
        }

    }
}
