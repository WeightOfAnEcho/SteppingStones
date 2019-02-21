using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Water : MonoBehaviour
{

    public GameObject dustPoof;
    public GameObject rockBlock;

    void Solidify()
    {

        Instantiate(dustPoof, transform.position, transform.rotation);
        Instantiate(rockBlock, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
