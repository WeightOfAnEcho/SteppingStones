using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Warp : BT_Player_Base
{

    public GameObject Target;
    public GameObject dustPuff;
    public BT_DynamicCamera dynamicCamera;


    //This exists incase any edits to player base is required -------------------------------------------------------------------------------------------------
    protected override void Awake()
    {
        base.Awake(); // start base functionality heled in BT_Player_Base
    }

    private void OnTriggerEnter(Collider other)
    {

            Instantiate(dustPuff, transform.position, transform.rotation);
            Agent.Warp(Target.transform.position);
            Instantiate(dustPuff, transform.position, transform.rotation);
            transform.LookAt(dynamicCamera.transform);
            StartCoroutine("WaitForEnding");

    }

    void Ender()
    {
        dynamicCamera.camera_move_enabled = true;
    }

    IEnumerator WaitForEnding() // delay coroutine for number of seconds delay
    {
        yield return new WaitForSeconds(4);
        Ender();
    }
}
