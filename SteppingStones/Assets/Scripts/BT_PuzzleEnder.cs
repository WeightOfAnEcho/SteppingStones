using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_PuzzleEnder : MonoBehaviour
{

    public bool staying;

    void FixedUpdate()
    {

        staying = false;
    }

    void OnCollisionStay(Collision other)
    {

        staying = true;
    }

    void Update()
    {

        if (staying)
        {
            Debug.Log("Colliding");
        }
        else
        {
            Debug.Log("Not colliding");
        }
    }
}
