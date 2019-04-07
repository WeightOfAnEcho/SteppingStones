using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_DynamicCamera : MonoBehaviour
{
   Camera MainCamera;
   public bool camera_move_enabled = false;

    public GameObject complete;
    public GameObject UI;

    private void Start()
    {
        MainCamera = gameObject.GetComponent<Camera>();
    }

    void Update()
    {

        if (camera_move_enabled)
        {
            StartCoroutine("WaitFor", 2);
        }

        if(MainCamera.orthographicSize >= 200)
        {
            complete.SetActive(true);
        }

        if (MainCamera.orthographicSize >= 750)
        {
            MainCamera.orthographicSize = 750;
        }
    }

    IEnumerator WaitFor(int seconds) // delay coroutine for number of seconds delay
    {
        yield return new WaitForSeconds(seconds);

        AnimateCamera();
    }

    void AnimateCamera()
    {
        UI.SetActive(false);
        MainCamera.orthographicSize += Time.deltaTime + 0.5f;
    }
}
