using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Platform_Riser : MonoBehaviour
{

    public GameObject[] platforms;
    public float speed = 0.2f;

    public Vector3 target;
    public Vector3 destination;

    public void Start()
    {
       
    }

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            print("button pressed");
            StartCoroutine(RaisePlatforms());
        }
    }

    private IEnumerator RaisePlatforms()
    {
        WaitForSeconds wait = new WaitForSeconds(1f); //specify amount of delay between rising platforms
        print("running coroutine");
        foreach (GameObject p in platforms) // run through array of platforms specified in inspector
        {
            print("raising" + p.name);


            //LERP SOLUTION TO SMOOTH MOVE PLATFORM 2 UNITS UP TO GO HERE.

            //CURRENT METHOD BELOW STILL TELEPORTS - LERP REQUIRES A CLEAR TARGET, I WAS TO AVOID HARD CODING TARGETS FOR EACH GO
            target = p.transform.position += Vector3.up * 2f;

            //p.transform.position = Vector3.Lerp(p.transform.position, target, speed * Time.deltaTime);

            yield return wait;
        }
    }
}
