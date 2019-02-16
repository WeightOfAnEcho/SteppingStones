using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Soul : MonoBehaviour
{
    public float speed = 10f;


    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Level 03 complete");
        }
    }
}
