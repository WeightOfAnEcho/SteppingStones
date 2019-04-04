using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BT_Water_Flower : MonoBehaviour
{
    public GameObject waterBlock;
    private bool spawned;
    public float spawnSpeed = 0.1f;

    public GameObject[] enemy;
    public float enemyCount;
    public float range;

    public GameObject list;
    BT_WaterList listScript;

    public GameObject iceBlock;
    GameObject WatertoAdd;

    // Start is called before the first frame update
    void Start()
    {
        listScript = GameObject.Find("BT_WaterList").GetComponent<BT_WaterList>();

        Invoke("WaterSpawn", spawnSpeed); // Begin water spawning (flowing) but with X delay
    }


    // WATER SPAWNING PROCESS //
    void WaterSpawn()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 lft = transform.TransformDirection(Vector3.left);
        Vector3 rgt = transform.TransformDirection(Vector3.right);
        Vector3 bck = transform.TransformDirection(Vector3.back);

        Vector3 dwn = transform.TransformDirection(Vector3.down); // For Waterfall (REQUIRES COLLIDER CONTAINER!)

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
            GameObject newWater = Instantiate(waterBlock, end, transform.rotation) as GameObject;
            listScript.Add(newWater);

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
            GameObject newWater = Instantiate(waterBlock, end, transform.rotation) as GameObject;
            listScript.Add(newWater);

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
            GameObject newWater = Instantiate(waterBlock, end, transform.rotation) as GameObject;
            listScript.Add(newWater);

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
            GameObject newWater = Instantiate(waterBlock, end, transform.rotation) as GameObject;
            listScript.Add(newWater);

        }

        if (Physics.Raycast(transform.position, dwn, out hit, 1))
        {
            if (hit.transform.tag == "Totem")
            {
                hit.transform.SendMessageUpwards("HitByWater");
            }

        }

        else
        {
            Vector3 end = transform.position + dwn;
            GameObject newWater = Instantiate(waterBlock, end, transform.rotation) as GameObject;
            listScript.Add(newWater);

        }

    }

    public void Regress() // function to be called by button
    {
        Invoke("WaterDeSpawn", spawnSpeed); // Begin water Despawning (regressing) but with X delay
        print("Invoking");
    } 

    void WaterDeSpawn()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 lft = transform.TransformDirection(Vector3.left);
        Vector3 rgt = transform.TransformDirection(Vector3.right);
        Vector3 bck = transform.TransformDirection(Vector3.back);
        Vector3 up = transform.TransformDirection(Vector3.up);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, 1))
        {
            if (hit.transform.tag == "water")
            {
                hit.transform.BroadcastMessage("Regress");
            }


            GameObject toDestroy = transform.parent.gameObject;
            listScript.waterInScene.Remove(toDestroy);
            Destroy(toDestroy/*transform.parent.gameObject*/);
        }


        if (Physics.Raycast(transform.position, rgt, out hit, 1))
        {
            if (hit.transform.tag == "water")
            {
                hit.transform.BroadcastMessage("Regress");
            }

            GameObject toDestroy = transform.parent.gameObject;
            listScript.waterInScene.Remove(toDestroy);
            Destroy(toDestroy/*transform.parent.gameObject*/);
        }

        if (Physics.Raycast(transform.position, lft, out hit, 1))
        {

            if (hit.transform.tag == "water")
            {
                hit.transform.BroadcastMessage("Regress");
            }

            GameObject toDestroy = transform.parent.gameObject;
            listScript.waterInScene.Remove(toDestroy);
            Destroy(toDestroy/*transform.parent.gameObject*/);
        }

        if (Physics.Raycast(transform.position, bck, out hit, 1))
        {

            if (hit.transform.tag == "water")
            {
                hit.transform.BroadcastMessage("Regress");
 
            }

            GameObject toDestroy = transform.parent.gameObject;
            listScript.waterInScene.Remove(toDestroy);
            Destroy(toDestroy/*transform.parent.gameObject*/);
        }


        if (listScript.waterInScene.Count == 0 || listScript.waterInScene == null)
        {
            listScript.waterPresent = false;
        }
    } 

    // FREEZING FUNCTIONALITY //

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
