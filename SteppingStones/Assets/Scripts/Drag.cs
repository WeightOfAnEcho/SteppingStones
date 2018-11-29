using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{
    public Camera IsoCam;

    void Start()
    {

    }

    void Update()
    {

    }
    

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        Vector3 curPosition = IsoCam.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;


    }

}

