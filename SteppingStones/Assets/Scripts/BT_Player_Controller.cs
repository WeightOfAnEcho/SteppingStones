using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BT_Player_Controller : MonoBehaviour
{

    //RAYCASTING/ CLICK TO MOVE REFERENCES ----------------------------------------------------------------------------------------
    public Camera IsoCam; //Main camera reference for RayCasting
    private NavMeshAgent Agent; //Reference for the Agent (player)

    //PLAYER ANIMATION ------------------------------------------------------------------------------------------------------------
    Animator AdirAnim; // Reference for the Player animator attached


    //SPAWNING AND DE-SPAWNING GAME OBJECTS ----------------------------------------------------------------------------------------
    public GameObject Staff; // reference for staff gameobject in scene (for picking up)
    public GameObject AttachedStaff; //reference for attached staff (when picked up)
    public GameObject Stone1;
    public GameObject Stone2;
    public GameObject Stone3;
    public GameObject Stone4;
    public GameObject Gate1;
    public GameObject Gate2;
    public GameObject ClickEffect; // reference for the effect when the ray cast lands a succesful hit on NavMesh

    void Start()
    {
        
        AdirAnim = GetComponent<Animator>(); // Fetch Animator component attached
        Agent = GetComponent<NavMeshAgent>(); // Fetch the Agent Properties
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // When the left mouse button is pressed
        {
            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition); // Fire a ray from the main camera to the click position
            RaycastHit hit; //store the resulting hit

            if (Physics.Raycast(ray, out hit, 500)) // if the hit coordiantes are on a valid collider within 500 units
            {

                if (hit.collider.gameObject.tag == "Staff") //if the raycast hits the Staff tagged game object
                {
                    print("HIT Staff");

                    AttachedStaff.SetActive(true); // set the attached staff to active
                    Staff.SetActive(false); // set the staff in the scene to false (fake picking up)
                    Gate1.SetActive(false); //set the drawn gate to false
                    Gate2.SetActive(true); // set the lowered gate to true
                    //Stone.GetComponent<BT_Drag>().MakeClickable();
                }

                NavMeshHit navmeshHit; // provide reference for a raycast hit on the navmesh
                int walkableMask = 1 << NavMesh.GetAreaFromName("Walkable"); // check if the nav mesh hit location was on a walkable layer/area

                if (NavMesh.SamplePosition(hit.point, out navmeshHit, 5, walkableMask)) //if the ray position returns a walkable sample position
                    
                {
                    print(hit.collider.gameObject.name);


                    NavMeshPath path = new NavMeshPath(); // create a reference for a nav mesh path
                    Agent.CalculatePath(navmeshHit.position, path); //The agent calculates a path to the hit location on nav mesh
                    Instantiate(ClickEffect, hit.point, Quaternion.LookRotation(hit.normal));//spawn the click effect at the hit location

                    if (path.status == NavMeshPathStatus.PathPartial) // if the agent calculates an impartial path
                    {
                        print("no path");
                    }

                    else
                    {
                        print("has path");
                        Agent.SetDestination(navmeshHit.position); // set the hit location on the nav mesh to the target destination for the agent
                    }

                    
                }

                if (hit.collider.gameObject.tag == "Stone1") //if the raycast hits the Stone 1 game object
                {

                    Stone1.SetActive(false);
                    Stone2.SetActive(true);

                }

                if (hit.collider.gameObject.tag == "Stone2") //if the raycast hits the Stone 2 game object
                {

                    Stone2.SetActive(false);
                    Stone3.SetActive(true);

                }
                if (hit.collider.gameObject.tag == "Stone3") //if the raycast hits the Stone 4 game object
                {

                    Stone3.SetActive(false);
                    Stone4.SetActive(true);

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
}

