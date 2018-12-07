using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BT_Highlight_Object : MonoBehaviour {


    private Renderer rend;
    private Color mouseOverColor = Color.green;
    private Color originalColor = Color.white;



    void Start()
    {

        rend = GetComponent<Renderer>();
    }

    void OnMouseEnter()
    {

        rend.material.color = mouseOverColor;

    }

    void OnMouseExit()
    {

        rend.material.color = originalColor;

    }




}


