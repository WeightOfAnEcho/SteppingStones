using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Lava_Flower : MonoBehaviour
{
    public GameObject lavaBlock;
    private bool spawned;
    public float spawnSpeed = 0.1f;



    // Start is called before the first frame update
    void Start()
    {

        Invoke("LavaSpawn", spawnSpeed); // Begin water spawning (flowing) but with X delay
    }



    // Update is called once per frame
    void LavaSpawn()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 lft = transform.TransformDirection(Vector3.left);
        Vector3 rgt = transform.TransformDirection(Vector3.right);
        Vector3 bck = transform.TransformDirection(Vector3.back);


        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, 1))
        {

            if (hit.transform.tag == "water")
            {
                hit.transform.SendMessageUpwards("Solidify");
            }

            if (hit.transform.tag == "Ice")
            {
                hit.transform.SendMessageUpwards("Melt");
            }

        }

        else
        {
            Vector3 end = transform.position + fwd;
            Instantiate(lavaBlock, end, transform.rotation);
        }

        if (Physics.Raycast(transform.position, rgt, out hit, 1))
        {
            if (hit.transform.tag == "water")
            {
                hit.transform.SendMessageUpwards("Solidify");
            }

            if (hit.transform.tag == "Ice")
            {
                hit.transform.SendMessageUpwards("Melt");
            }
        }

        else
        {
            Vector3 end = transform.position + rgt;
            Instantiate(lavaBlock, end, transform.rotation);
        }

        if (Physics.Raycast(transform.position, lft, out hit, 1))
        {
            if (hit.transform.tag == "water")
            {
                hit.transform.SendMessageUpwards("Solidify");
            }

            if (hit.transform.tag == "Ice")
            {
                hit.transform.SendMessageUpwards("Melt");
            }
        }

        else
        {
            Vector3 end = transform.position + lft;
            Instantiate(lavaBlock, end, transform.rotation);
        }

        if (Physics.Raycast(transform.position, bck, out hit, 1))
        {
            if (hit.transform.tag == "water")
            {
                hit.transform.SendMessageUpwards("Solidify");
            }

            if (hit.transform.tag == "Ice")
            {
                hit.transform.SendMessageUpwards("Melt");
            }
        }

        else
        {
            Vector3 end = transform.position + bck;
            Instantiate(lavaBlock, end, transform.rotation);
        }

    }
}
