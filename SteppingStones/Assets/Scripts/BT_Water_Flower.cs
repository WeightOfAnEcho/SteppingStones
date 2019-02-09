using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Water_Flower : MonoBehaviour
{

    public GameObject waterBlock;
    private bool spawned;
    public float spawnSpeed = 0.1f;

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
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow);
            print("hit wall");
            Debug.Log(hit.transform.gameObject.name);

        }

        else
        {
            Vector3 end = transform.position + fwd;
            Instantiate(waterBlock, end, Quaternion.identity);
        }

        if (Physics.Raycast(transform.position, rgt, out hit, 1))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.yellow);
            print("hit wall");
            Debug.Log(hit.transform.gameObject.name);
        }

        else
        {
            Vector3 end = transform.position + rgt;
            Instantiate(waterBlock, end, Quaternion.identity);
        }

    }
}
