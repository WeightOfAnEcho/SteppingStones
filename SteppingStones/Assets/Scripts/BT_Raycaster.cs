using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Raycaster : MonoBehaviour
{
    private bool cooldown = false;
    public Camera IsoCam; //Main camera reference for RayCasting


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldown == false) // When the left mouse button is pressed
        {
            Invoke("ResetCooldown", 0.5f);
            cooldown = true;

            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition); // Fire a ray from the main camera to the click position
            RaycastHit hit; //store the resulting hit

            if (Physics.Raycast(ray, out hit, 500)) // if the hit coordiantes are on a valid collider within 500 units
            {

                print(hit.collider.gameObject);
                hit.collider.SendMessageUpwards("BeginRotation", SendMessageOptions.RequireReceiver);
                
            }
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}
