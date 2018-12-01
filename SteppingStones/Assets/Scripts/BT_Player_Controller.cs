using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BT_Player_Controller : MonoBehaviour
{
    public Camera IsoCam; //Main camera reference for RayCasting
    public NavMeshAgent Agent; //Reference for the Agent (player)
    Animator AdirAnim; // Reference for the Player animator attached
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // When the left mouse button is pressed
        {
            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition); // Fire a ray from the main camera to the click position
            RaycastHit hit; //store the resulting hit

            if (Physics.Raycast(ray, out hit, 500)) // if the hit coordiantes are on a valid collider
            {

                if (hit.collider.gameObject.tag == "Staff") //if the raycast hits the Staff game object
                {
                    print("HIT Staff");
                    AttachedStaff.SetActive(true); // set the attached staff to active
                    Staff.SetActive(false); // set the staff in the scene to false (fake picking up)
                    Gate1.SetActive(false);
                    Gate2.SetActive(true);
                    //Stone.GetComponent<BT_Drag>().MakeClickable();
                }

                NavMeshHit navmeshHit;
                int walkableMask = 1 << NavMesh.GetAreaFromName("Walkable");

                if (NavMesh.SamplePosition(hit.point, out navmeshHit, 5.0f, walkableMask))
                    
                {
                    //Move the Player and start the walking animation
                    print(hit.collider.gameObject.name);
                    Instantiate(ClickEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Agent.SetDestination(navmeshHit.position);
                }

                if (hit.collider.gameObject.tag == "Stone1") //if the raycast hits the Staff game object
                {

                    Stone1.SetActive(false);
                    Stone2.SetActive(true);

                }

                if (hit.collider.gameObject.tag == "Stone2") //if the raycast hits the Staff game object
                {

                    Stone2.SetActive(false);
                    Stone3.SetActive(true);

                }
                if (hit.collider.gameObject.tag == "Stone3") //if the raycast hits the Staff game object
                {

                    Stone3.SetActive(false);
                    Stone4.SetActive(true);

                }

            }
        }

        // ANIMATION CONTROLLING BASED ON DISTANCE FROM TARGET

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

