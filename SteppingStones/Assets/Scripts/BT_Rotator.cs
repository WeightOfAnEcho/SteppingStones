using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_Rotator : MonoBehaviour
{
    public BT_WaterList check; // a public variable for the button press script

    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // Create a temporary reference to the current scene.

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Level_3" || sceneName == "05_LV_V4") // if this is X scene, do a single automatic rotation
        {
            StartCoroutine(Rotate(Vector3.up, 90, 1.0f)); // start the rotation coroutine
        }
    }

    public void BeginRotation()
    {
        if (check.waterPresent == false) // check if the water is flowing (boolean from the button press script variable)
        {
            StartCoroutine(Rotate(Vector3.up, 90, 1.0f));
        }

    }


    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
    }

}
