using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Water_Flower : MonoBehaviour
{

    public GameObject waterBlock;
    private bool spawned;
    public float spawnSpeed = 0.1f;

    private bool gravity = false; //not working. turns on spawning of water downwards
    private int waterLimit = 50; //not working. limits the number of water to be spawned, as to not melt computers 

    public GameObject iceBlock;

    // Start is called before the first frame update
    void Start()
    {

        Invoke("WaterSpawn", spawnSpeed); // Begin water spawning (flowing) but with X delay
    }



    // Update is called once per frame
    void WaterSpawn()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 lft = transform.TransformDirection(Vector3.left);
        Vector3 rgt = transform.TransformDirection(Vector3.right);
        Vector3 bck = transform.TransformDirection(Vector3.back);

        Vector3 dwn = transform.TransformDirection(Vector3.down);

        int counter = 0; //counts how many water block have been spawned

        RaycastHit hit;

        if (counter < waterLimit)
        {
            //Debug.Log(counter);

            if (Physics.Raycast(transform.position, fwd, out hit, 1))
            {

                if (hit.transform.tag == "Totem")
                {
                    hit.transform.SendMessageUpwards("HitByWater");
                }


                if (hit.transform.tag == "Ice")
                {
                    //Freeze();
                }

            }

            else
            {
                Vector3 end = transform.position + fwd;
                Instantiate(waterBlock, end, transform.rotation);
                counter++;
            }

            if (Physics.Raycast(transform.position, rgt, out hit, 1))
            {

                if (hit.transform.tag == "Totem")
                {
                    hit.transform.SendMessageUpwards("HitByWater");
                }


                if (hit.transform.tag == "Ice")
                {
                    //Freeze();
                }
            }

            else
            {
                Vector3 end = transform.position + rgt;
                Instantiate(waterBlock, end, transform.rotation);
                counter++;
            }

            if (Physics.Raycast(transform.position, lft, out hit, 1))
            {

                if (hit.transform.tag == "Totem")
                {
                    hit.transform.SendMessageUpwards("HitByWater");
                }


                if (hit.transform.tag == "Ice")
                {
                    //Freeze();
                }
            }

            else
            {
                Vector3 end = transform.position + lft;
                Instantiate(waterBlock, end, transform.rotation);
                counter++;
            }

            if (Physics.Raycast(transform.position, bck, out hit, 1))
            {

                if (hit.transform.tag == "Totem")
                {
                    hit.transform.SendMessageUpwards("HitByWater");
                }

                if (hit.transform.tag == "Ice")
                {
                    //Freeze();
                }
            }

            else
            {
                Vector3 end = transform.position + bck;
                Instantiate(waterBlock, end, transform.rotation);
                counter++;
            }

            if (gravity)
            {
                if (Physics.Raycast(transform.position, dwn, out hit, 1))
                {

                    if (hit.transform.tag == "Totem")
                    {
                        hit.transform.SendMessageUpwards("HitByWater");
                    }

                    if (hit.transform.tag == "Ice")
                    {
                        //Freeze();
                    }
                }

                else
                {
                    Vector3 end = transform.position + bck;
                    Instantiate(waterBlock, end, transform.rotation);
                    counter++;
                }
            }

        }
    }



    public void Regress() // function to be called by button
    {
        Invoke("WaterDeSpawn", spawnSpeed); // Begin water Despawning (regressing) but with X delay
    } // not functioning

    void WaterDeSpawn()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 lft = transform.TransformDirection(Vector3.left);
        Vector3 rgt = transform.TransformDirection(Vector3.right);
        Vector3 bck = transform.TransformDirection(Vector3.back);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, 1))
        {

            if (hit.transform.tag == "Totem")
            {
                hit.transform.SendMessageUpwards("HitByWater");
            }

        }

        else
        {
            Vector3 end = transform.position + fwd;
            Instantiate(waterBlock, end, transform.rotation);
        }

        if (Physics.Raycast(transform.position, rgt, out hit, 1))
        {

            if (hit.transform.tag == "Totem")
            {
                hit.transform.SendMessageUpwards("HitByWater");
            }
        }

        else
        {
            Vector3 end = transform.position + rgt;
            Instantiate(waterBlock, end, transform.rotation);
        }

        if (Physics.Raycast(transform.position, lft, out hit, 1))
        {

            if (hit.transform.tag == "Totem")
            {
                hit.transform.SendMessageUpwards("HitByWater");
            }
        }

        else
        {
            Vector3 end = transform.position + lft;
            Instantiate(waterBlock, end, transform.rotation);
        }

        if (Physics.Raycast(transform.position, bck, out hit, 1))
        {

            if (hit.transform.tag == "Totem")
            {
                hit.transform.SendMessageUpwards("HitByWater");
            }
        }

        else
        {
            Vector3 end = transform.position + bck;
            Instantiate(waterBlock, end, transform.rotation);
        }

    } // not functioning


    public void Freeze() // freeze function called by ice when water collides
    {
        StartCoroutine(FreezeCycle()); // beging freezing - coroutine to allow for non-immediate freezing + processing time

    }

    IEnumerator FreezeCycle()
    {
        yield return new WaitForSeconds(0.5f); // delay before 'freezing'

        Instantiate(iceBlock, transform.position, transform.rotation); // instatiate an icebock - this then collides with the adjacent water and restarts the freezing process

        Destroy(transform.parent.gameObject); // destory the parent (and this) remember this script is attached to the raycaster cube, not the water block!
    }

}
