using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_Rotator : MonoBehaviour
{
    public GameObject checkerCube;

    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // Create a temporary reference to the current scene.

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Level_3") // if this is X scene, do a single automatic rotation
        {
            StartCoroutine(Rotate(Vector3.up, 90, 1.0f));
        }
    }

    public void BeginRotation()
    {

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 lft = transform.TransformDirection(Vector3.left);
        Vector3 rgt = transform.TransformDirection(Vector3.right);
        Vector3 bck = transform.TransformDirection(Vector3.back);
        Vector3 all = transform.TransformDirection(Vector3.one);

        RaycastHit hit;

        //if (Physics.Raycast(checkerCube.transform.position, fwd, out hit, 1))
        //{

        //    if (hit.transform.tag == "water")
        //    {
        //        print("hit water");
        //    }

        //}

        //if (Physics.Raycast(checkerCube.transform.position, lft, out hit, 1))
        //{

        //    if (hit.transform.tag == "water")
        //    {
        //        print("hit water");
        //    }

        //}

        //if (Physics.Raycast(checkerCube.transform.position, rgt, out hit, 1))
        //{

        //    if (hit.transform.tag == "water")
        //    {
        //        print("hit water");
        //    }

        //}

        //if (Physics.Raycast(checkerCube.transform.position, bck, out hit, 1))
        //{

        //    if (hit.transform.tag == "water")
        //    {
        //        print("hit water");
        //    }

        //}

        //else
        //{
            StartCoroutine(Rotate(Vector3.up, 90, 1.0f));
        //}


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

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }

}
