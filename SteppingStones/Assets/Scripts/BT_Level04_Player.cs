using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Level04_Player : BT_Player_Base
{

    public GameObject[] Targets;


    public GameObject dustPuff;

    //This exists incase any edits to player base is required -------------------------------------------------------------------------------------------------
    void Start()
    {
        base.Awake(); // start base functionality heled in BT_Player_Base
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Geyser01")
        {

            Instantiate(dustPuff, transform.position, transform.rotation);
            Agent.Warp(Targets[0].transform.position);
            Instantiate(dustPuff, transform.position, transform.rotation);
        }

        if (other.gameObject.tag == "Geyser02")
        {

            Instantiate(dustPuff, transform.position, transform.rotation);
            Agent.Warp(Targets[1].transform.position);
            Instantiate(dustPuff, transform.position, transform.rotation);
        }

        if (other.gameObject.tag == "Geyser03")
        {

            Instantiate(dustPuff, transform.position, transform.rotation);
            Agent.Warp(Targets[2].transform.position);
            Instantiate(dustPuff, transform.position, transform.rotation);
        }
    }



}
