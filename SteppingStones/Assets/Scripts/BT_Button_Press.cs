using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Button_Press : MonoBehaviour
{

    public ParticleSystem system;
    public GameObject[] waterBlocks;

    private void OnCollisionEnter(Collision collision)
    {
        system.Stop();

        //water flow function start here

    }

    private void OnCollisionExit(Collision collision)
    {
        system.Play();

        //water regress function here

    }
}

