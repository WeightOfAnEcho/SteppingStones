using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Water_Flower : MonoBehaviour
{

    public GameObject waterBlock;
    private bool spawned;
    public float spawnSpeed = 0.1f;

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


        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, 1))
        {

            if (hit.transform.tag == "Totem")
            {
                hit.transform.SendMessageUpwards("HitByWater");
            }


            if (hit.transform.tag == "Ice")
            {
                Freeze();
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


            if (hit.transform.tag == "Ice")
            {
                Freeze();
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


            if (hit.transform.tag == "Ice")
            {
                Freeze();
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

            if (hit.transform.tag == "Ice")
            {
                Freeze();
            }
        }

        else
        {
            Vector3 end = transform.position + bck;
            Instantiate(waterBlock, end, transform.rotation);
        }

    }

    public void Regress() // function to be called by button
    {
        Invoke("WaterDeSpawn", spawnSpeed); // Begin water Despawning (regressing) but with X delay
    }

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

    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    void Freeze()
    {
        Instantiate(iceBlock, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
