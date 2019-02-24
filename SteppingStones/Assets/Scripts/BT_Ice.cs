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

    private void OnCollisionEnter(Collision collision) // when water collides with ice
    {

        if (collision.gameObject.tag == "water") // ensure it's water colliding with the ice
        {
            collision.transform.BroadcastMessage("Freeze"); // tell the water to execute freeze function
        }

    }

}
