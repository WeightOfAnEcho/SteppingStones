using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Summit_Spinner : MonoBehaviour
{

    public int spinDegrees; // by how much do you want objkect to spin (90 degrees, 180 degrees etc.)
    public float spinSpeed; // speed of rotation - higher number, slower speed.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(Rotate(Vector3.up, spinDegrees, spinSpeed));
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
}
