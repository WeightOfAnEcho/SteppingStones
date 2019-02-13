using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BT_Player_Base: MonoBehaviour //this contains base functionality for player and can then be modified in a level specific version
    {

    //RAYCASTING/ CLICK TO MOVE REFERENCES ----------------------------------------------------------------------------------------
    public Camera IsoCam; //Main camera reference for RayCasting
    private NavMeshAgent Agent; //Reference for the Agent (player)

    //PLAYER ANIMATION ------------------------------------------------------------------------------------------------------------
    Animator AdirAnim; // Reference for the Player animator attached

    public GameObject ClickEffect; // reference for the effect when the ray cast lands a succesful hit on NavMesh

    private bool cooldown = false;

    void Start()
    {

        AdirAnim = GetComponent<Animator>(); // Fetch Animator component attached
        Agent = GetComponent<NavMeshAgent>(); // Fetch the Agent Properties
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldown == false) // When the left mouse button is pressed
        {
            Invoke("ResetCooldown", 2f);
            cooldown = true;

            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition); // Fire a ray from the main camera to the click position
            RaycastHit hit; //store the resulting hit

            if (Physics.Raycast(ray, out hit, 500)) // if the hit coordiantes are on a valid collider within 500 units
            {


                NavMeshHit navmeshHit; // provide reference for a raycast hit on the navmesh
                int walkableMask = 1 << NavMesh.GetAreaFromName("Walkable"); // check if the nav mesh hit location was on a walkable layer/area

                if (NavMesh.SamplePosition(hit.point, out navmeshHit, 5.5f, walkableMask)) //if the ray position returns a walkable sample position                   
                {
                    print(hit.collider.gameObject.name + ", " + navmeshHit.mask);

                    NavMeshPath path = new NavMeshPath(); // create a reference for a nav mesh path
                    Agent.CalculatePath(navmeshHit.position, path); //The agent calculates a path to the hit location on nav mesh
                    Instantiate(ClickEffect, hit.point, Quaternion.LookRotation(hit.normal));//spawn the click effect at the hit location

                    if (path.status != NavMeshPathStatus.PathComplete) // if the agent calculates an impartial path
                    {
                        print("no path");

                    }

                    else if (path.status == NavMeshPathStatus.PathComplete) // if the agent calculates a full path to destination point
                    {
                        print("has path");
                        Agent.SetDestination(navmeshHit.position); // set the hit location on the nav mesh to the target destination for the agent

                    }
                }

            }
        }

        // ANIMATION CONTROLLING BASED ON DISTANCE FROM TARGET DESTINATION -----------------------------------------------------------------------------

        if (Agent.remainingDistance > Agent.stoppingDistance) // If remaining distance on path is greater than stopping distance
        {
            AdirAnim.SetBool("Walking", true); // play walking animation
        }

        else
        {
            AdirAnim.SetBool("Walking", false); //stop playing walking animation
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}

