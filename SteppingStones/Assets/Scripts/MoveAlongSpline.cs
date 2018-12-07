using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongSpline : MonoBehaviour
{
    public GameObject[] myWayPoints = new GameObject[2];
    public Camera IsoCam;

    // Use this for initialization
    void Start()
    {
        if (myWayPoints.Length == 0)
        {
            print("No Waypoints");
        }

        if (gameObject.transform.position.y != myWayPoints[0].transform.position.y)
        {
            transform.position = myWayPoints[0].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseMoveAlongSpline();
    }

    void MouseMoveAlongSpline()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            float startJourney = myWayPoints[0].transform.position.x;
            float endJourney = myWayPoints[1].transform.position.x;
            float lengthJourney = endJourney - startJourney;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                float myProgress = hit.point.x;

                //print("Actual HitPoint: " + hit.point.x);
                //print(hit.point.x + (Vector3.Distance(myWayPoints[0].transform.position, myWayPoints[1].transform.position) / 2) + ", Name: " + hit.collider.name);

                float myT = (lengthJourney - myProgress) / 10;

                print("lengthJourney: " + lengthJourney + ", myProgress: " + myProgress + ", myT: " + myT);

                transform.position = Vector3.Lerp(myWayPoints[0].transform.position, myWayPoints[1].transform.position, myT);
            }
        }
    }
}
