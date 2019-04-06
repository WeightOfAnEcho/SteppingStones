using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BT_Highlight_Object : MonoBehaviour {


    public Renderer[] rends;
    public Material mouseOverColor;
    public Material originalColor;

    public BT_WaterList check; // a public variable for the button press script


    void Start()
    {

        


    }

    void OnMouseEnter()
    {
        Debug.Log("Name: " + gameObject.name);

        rends = GetComponentsInChildren<Renderer>(); // fetch the redners of children this is attached to

        foreach (Renderer rend in rends) // for each found rednerer
        {
            if (rend.gameObject.transform.parent != null && check.waterPresent == false) // ensure we aren't including the parent renderer
            {
                //print("changing color");
                rend.material = mouseOverColor; // change the material to the pressed material
            }
        }


    }

    void OnMouseExit()
    {
        //Debug.Log("Name: " + gameObject.name);

        rends = GetComponentsInChildren<Renderer>(); // fetch the redners of children this is attached to

        foreach (Renderer rend in rends) // for each found rednerer
        {
            if (rend.gameObject.transform.parent != null) // ensure we aren't including the parent renderer
            {
                rend.material = originalColor; // change the material to the pressed material
            }
        }


    }




}


