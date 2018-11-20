using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera IsoCam;
    public NavMeshAgent Agent;
    Animator AdirAnim;
    public float AdirVelocity;
    private Rigidbody Rb;
    //private bool Walking= false;



    void Start()
    {
        AdirAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            float velocity = Agent.velocity.magnitude;

            if (Physics.Raycast(ray, out hit))
            {
                //Move the Player

                Agent.SetDestination(hit.point);

                
                if (velocity != 0)
                {
                    Debug.Log("Moving");
                    AdirAnim.SetBool("Walking", true);
                }
                else
                {
                    AdirAnim.SetBool("Walking", false);
                }


                //Walking = true;
                //Animate();
            }
        }

    }

    //void Animate()
    //{
    //    if (Walking == true )
    //    {
    //        Debug.Log("Moving");
    //        AdirAnim.SetBool("Walking", true);
    //    }

    //    if (Walking == false)
    //    {
    //        AdirAnim.SetBool("Walking", false);
    //    }

    //}
}

