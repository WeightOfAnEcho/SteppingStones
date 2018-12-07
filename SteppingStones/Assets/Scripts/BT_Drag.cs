using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BT_Drag : MonoBehaviour
{
    public Camera IsoCam;

    public Transform pointA, pointB;

    private Renderer rend;
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.white;
    private bool clickable = false;
    private bool dragging = false;

    public float slideSpeed;



    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (dragging)
        {
           
        }
    }

    public void MakeClickable()
    {
        print("changing layer");
        gameObject.layer = LayerMask.NameToLayer("Default");
        print("new layer");
        clickable = true;
    }

    void OnMouseEnter()
    {

       rend.material.color = mouseOverColor;
        
    }

    void OnMouseExit()
    {

     rend.material.color = originalColor;
        
    }

    void OnMouseDown()
    {
        dragging = true;
    }


    void OnMouseUp()
    {
        dragging = false;
    }

}

