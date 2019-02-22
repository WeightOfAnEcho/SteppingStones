using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV_GetSplinePos : MonoBehaviour
{
    public Vector3 GetSplinePosition(Vector3 pos)
    {
        float splinePoint;
        Vector3 splinePosition;
        splinePoint = gameObject.GetComponent<Spline>().ClosestPoint(pos, 100);
        splinePosition = gameObject.GetComponent<Spline>().GetPosition(splinePoint, true, 100);

        return splinePosition;
    }

}
