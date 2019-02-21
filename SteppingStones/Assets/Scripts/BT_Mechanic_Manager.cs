using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_Mechanic_Manager : MonoBehaviour
{


 public void LoadNext()
    {
        SceneManager.LoadScene("Mechanics2"); //load the next mechanics scene
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
        SceneManager.LoadScene("Mechanics"); // load the first mechanics scene
    }
}
