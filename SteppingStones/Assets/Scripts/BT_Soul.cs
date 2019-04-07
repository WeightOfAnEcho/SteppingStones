using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_Soul : MonoBehaviour
{
    public float speed = 10f; // spin speed of Lost Soul - can be altered in inspector


    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime); // spins the lost soul - helpful telegraphing
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print(collision.gameObject.name);

            Scene currentScene = SceneManager.GetActiveScene(); // Create a temporary reference to the current scene.
            string sceneName = currentScene.name;

            if (sceneName == "Level_3")
            {
                PlayerPrefs.SetInt("Level01Complete", 1); // unlock the forest level
                PlayerPrefs.SetInt("Level02Complete", 1); //unlock BoM level
                PlayerPrefs.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                print("setPref 01 and 02");
            }
            if (sceneName == "AW_Level_04")
            {
                PlayerPrefs.SetInt("Level03Complete", 1); // Unlock Summit Level
                PlayerPrefs.Save();
                print("setPref 03");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (sceneName == "01_LV")
            {
                //PlayerPrefs.SetInt("Level02Complete", 1); // Unlock x Level
                //PlayerPrefs.Save();
                //print("setPref 03");
               // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
