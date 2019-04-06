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
                PlayerPrefs.SetInt("Level02Complete", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (sceneName == "AW_Level_04")
            {
                SceneManager.LoadScene(0); //temporary code to loop back to menu
                PlayerPrefs.SetInt("Level03", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
