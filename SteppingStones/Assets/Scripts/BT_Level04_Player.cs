﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Level04_Player : BT_Player_Base
{

    public GameObject[] Targets;


    public GameObject dustPuff;

    //This exists incase any edits to player base is required -------------------------------------------------------------------------------------------------
    protected override void Start()
    {
        base.Start(); // start base functionality heled in BT_Player_Base
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Geyser01")
        {
            print("Teleport01");
            Instantiate(dustPuff, transform.position, transform.rotation);
            Agent.Warp(Targets[0].transform.position);
            Instantiate(dustPuff, transform.position, transform.rotation);
        }
    }



}