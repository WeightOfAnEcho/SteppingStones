using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera IsoCam; //Main camera reference for RayCasting
    public NavMeshAgent Agent; //Reference for the Agent (player)
    Animator AdirAnim; // Reference for the Player animator attached

    void Start()
    {
        AdirAnim = GetComponent<Animator>(); // Fetch Animator component attached
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // When the left mouse button is pressed
        {
            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition); // Fire a ray from the main camera to the click position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // if the hit coordiantes are on a valid location on the Nav Mesh
            {
                //Move the Player and start the walking animation
                Agent.SetDestination(hit.point);
                Debug.Log("Moving");
                AdirAnim.SetBool("Walking", true);


                // now need a function or method that notes the Agent is no longer moving to destination or has reached its destination and therefore no longer walking
            }
        }

    }
}

