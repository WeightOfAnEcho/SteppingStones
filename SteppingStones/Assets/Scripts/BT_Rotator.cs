using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Rotator : MonoBehaviour
{

    private bool cooldown = false;
    public Camera IsoCam; //Main camera reference for RayCasting
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldown == false) // When the left mouse button is pressed
        {
            Invoke("ResetCooldown", 2f);
            cooldown = true;

            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition); // Fire a ray from the main camera to the click position
            RaycastHit hit; //store the resulting hit

            if (Physics.Raycast(ray, out hit, 500)) // if the hit coordiantes are on a valid collider within 500 units
            {
                StartCoroutine(Rotate(Vector3.up, 90, 1.0f));
            }
        }
    }

    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
    }

     void ResetCooldown()
    {
        cooldown = false;
    }
}
