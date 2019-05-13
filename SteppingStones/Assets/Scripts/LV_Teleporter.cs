using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LV_Teleporter : MonoBehaviour
{
    public GameObject GO_Player; //player character to teleport
    //private Transform IN; //where player enters teleporter
    public Vector3 OUT; //position player is telported to
    private NavMeshAgent navAgent;
    public GameObject dustPoof;
    

    // Start is called before the first frame update
    void Start()
    {
        //IN = GetComponent<Transform>();
        navAgent = GO_Player.GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == GO_Player)
        {
            //Debug.Log("skrrrt");
            navAgent.Warp(OUT);
            Instantiate(dustPoof, GO_Player.transform.position, GO_Player.transform.rotation);
        }
    }

}
