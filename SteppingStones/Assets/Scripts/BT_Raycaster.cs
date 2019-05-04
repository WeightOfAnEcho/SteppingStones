using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Raycaster : MonoBehaviour
{
    public static bool cooldown = false; // publicly accessible boolean for global cooldown of click
    public Camera IsoCam; //Main camera reference for RayCasting  


    void Start()
    {
        cooldown = false;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && cooldown == false) // When the left mouse button is pressed
        {
            Invoke("ResetCooldown", 1f); // being cooldown
            cooldown = true;

            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition); // Fire a ray from the main camera to the click position
            RaycastHit hit; //store the resulting hit

            if (Physics.Raycast(ray, out hit, 500)) // if the hit coordiantes are on a valid collider within 500 units
            {
                //print(hit.collider.name);

                if (hit.transform.tag == "Valve")
                {
                    hit.collider.SendMessageUpwards("BeginRotation", SendMessageOptions.DontRequireReceiver); // send message up hierarchy until you hit object with script attached
                    //doesn't require receivier to avoid issue with null reference when you click the parent/object with script
                }

                
            }
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}
