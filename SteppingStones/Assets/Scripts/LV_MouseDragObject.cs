using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Drags gameObject along surface (Y axis)
 * Attach to gameObject you want to drag
*/
public class LV_MouseDragObject : MonoBehaviour
{
    float planeY; //defining where ground is

    private void OnMouseDrag()
    {
        mouseDragMoveObject();
    }

    void mouseDragMoveObject()
    {
        Transform draggingObject = transform;

        planeY = transform.position.y;
        Plane plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance; // the distance from the ray origin to the ray intersection of the plane

        if (plane.Raycast(ray, out distance))
        {
            draggingObject.position = ray.GetPoint(distance); // distance along the ray
        }

    }

}
