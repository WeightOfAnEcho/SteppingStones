using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_Soul : MonoBehaviour
{
    public float speed = 10f; // spin speed of Lost Soul - can be altered in inspector
    public MusicFader fadeOut; // for fading music in and out - camera is reference as audio source is attached there

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime); // spins the lost soul - helpful telegraphing
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //print(collision.gameObject.name);

            Scene currentScene = SceneManager.GetActiveScene(); // Create a temporary reference to the current scene.
            string sceneName = currentScene.name;

            if (sceneName == "Level_0") // if tutorial
            {
                fadeOut.EndLevel();
                PlayerPrefs.SetInt("Level00Complete", 1); // unlock the forest level
                PlayerPrefs.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            if (sceneName == "01_LV") // if beach
            {
                fadeOut.EndLevel();
                PlayerPrefs.SetInt("Level01Complete", 1); // Unlock x Level
                PlayerPrefs.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            if (sceneName == "Level_3") // if forest
            {
                fadeOut.EndLevel();
                PlayerPrefs.SetInt("Level02Complete", 1); //unlock BoM level
                PlayerPrefs.Save();
                print("setPref 02");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

            if (sceneName == "AW_Level_04") // if base of mountain
            {
                fadeOut.EndLevel();
                PlayerPrefs.SetInt("Level03Complete", 1); // Unlock Summit Level
                PlayerPrefs.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            if (sceneName == "05_LV_V4")
            {
                fadeOut.EndLevel();
                PlayerPrefs.SetInt("Level04Complete", 1); // Unlock Summit Level
                PlayerPrefs.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            if (sceneName == "AW_Summit_#1")
            {
                fadeOut.EndLevel();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }


        }
    }
}
