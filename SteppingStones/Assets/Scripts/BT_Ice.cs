using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Ice : MonoBehaviour
{
    public GameObject rockBlock;
    public GameObject dustPoof;


    void Melt()
    {
        Instantiate(dustPoof, transform.position, transform.rotation);
        Instantiate(rockBlock, transform.position, transform.rotation);
        Destroy(gameObject);

    }


}
