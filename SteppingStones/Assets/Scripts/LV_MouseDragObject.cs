using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;


/*
 * Drags gameObject along surface (Y axis)
 * Attach to gameObject you want to drag
*/
public class LV_MouseDragObject : MonoBehaviour
{
    float planeY; //defining where ground is
    public GameObject GO_spline;

    private void OnMouseDrag()
    {
        mouseDragMoveObject();
    }

    void mouseDragMoveObject()
    {
        
        Transform draggingObject = transform;
        Vector3 initial_position;
        Vector3 final_position;

        planeY = transform.position.y;
        Plane plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance; // the distance from the ray origin to the ray intersection of the plane

        if (plane.Raycast(ray, out distance))
        {
 
            initial_position = ray.GetPoint(distance);

            final_position = restrictPosToSpline(draggingObject.position);

            if (!isSkipping(initial_position, final_position))
            {
                Vector3 mouse_pos = ray.GetPoint(distance);
                draggingObject.position = restrictPosToSpline(mouse_pos);
            }
            else if(isSkipping(initial_position, final_position))
            {
                draggingObject.position = final_position;
            }
        }
    }

    private Vector3 restrictPosToSpline(Vector3 pos)
    {
        float splinePoint;
        Vector3 splinePosition;
        splinePoint = GO_spline.GetComponent<Spline>().ClosestPoint(pos, 100);
        splinePosition = GO_spline.GetComponent<Spline>().GetPosition(splinePoint, true, 100);

        return splinePosition;
    }

    private bool isSkipping(Vector3 initial_pos, Vector3 final_pos)
    {
        float max_distance = 1.5f;
        float distance = Vector3.Distance(initial_pos, final_pos);

        if(distance > max_distance)
        {
            //Debug.Log("too far away");
            return true;
        }
        else
        {
            //Debug.Log("close enough");
            return false;
        }
    }

}
