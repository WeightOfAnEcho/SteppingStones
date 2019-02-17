using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Button_Press : MonoBehaviour
{

    //WATER SPAWNING AND DESPAWNING -------------------------------------------------------------------------------------------------
    public GameObject[] waterBlocks; // array of waterblocks in scene (filled in function below)
    public GameObject waterBlock; // Single waterblock for instatiating
    public Transform spawnPoint; // spawn point reference to instatiate water - can be placed wherever
    private bool isCreated = false; // boolean to avoid duplication

    public bool isFlowing = false; // boolean to ensure we can't rotate valves while water is spawned (accessed by BT_Rotator script)

    // BUTTON PRESSED TELEGRAPHING -------------------------------------------------------------------------------------------------
    public Component[] rends; // Collects renderers in array for material changing
    public Material pressed; // pressed material to change to
    public Material notPressed; // not pressed material to change back to
    public ParticleSystem system; // particle system to show button can be interacted with

    private void OnCollisionEnter(Collision collision) // when the something enters collider (pressed button)
    {

        if (collision.gameObject.tag == "Player") //is that something the player?
        {
            system.Stop(); // stop the particle system - stopping makes it naturally fade rather than disappear
            isFlowing = true;
            rends = GetComponentsInChildren<Renderer>(); // fetch the redners of children this is attached to

            foreach (Renderer rend in rends) // for each found rednerer
            {
                if (rend.gameObject.transform.parent != null) // ensure we aren't including the parent renderer
                {
                    rend.material = pressed; // change the material to the pressed material
                }
            }
                

            if (!isCreated) // if there isn't already a water block (stop duplicate spawns)
            {
                Instantiate(waterBlock, spawnPoint.position, spawnPoint.rotation); // instantiate a water block at the spawn point
                isCreated = true; // set created bool to true to avoid duplicates

            }

        }


    }

    private void OnCollisionExit(Collision collision) // when player is no longer colliding
    {

        foreach (Renderer rend in rends)
        {
            if (rend.gameObject.transform.parent != null)
            {
                rend.material = notPressed; // switch to not pressed material
            }
        }

        isFlowing = false;
        waterBlocks = GameObject.FindGameObjectsWithTag("water"); // find all objects in scene tagged water

        for (var i = 0; i < waterBlocks.Length; i++) // for each object in array
        {
            Destroy(waterBlocks[i]); // destory - a more elgant method of removal will be used in beta
           
        }

        isCreated = false; // reset boolean to allow new water to be spawned
    }
}

