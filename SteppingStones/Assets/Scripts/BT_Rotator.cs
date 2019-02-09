using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Rotator : MonoBehaviour
{

    public void BeginRotation()
    {

        StartCoroutine(Rotate(Vector3.up, 90, 1.0f));
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
