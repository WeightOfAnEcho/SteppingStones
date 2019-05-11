using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_FinalSoul : MonoBehaviour
{

    public Transform target;
    public float speed;
    public BT_DynamicCamera dynamicCamera;

    public void Start()
    {
        StartCoroutine("WaitForEnding");
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }

    void Ender()
    {
        dynamicCamera.camera_move_enabled = true;
    }

    IEnumerator WaitForEnding() // delay coroutine for number of seconds delay
    {
        yield return new WaitForSeconds(8);
        Ender();
    }
}
