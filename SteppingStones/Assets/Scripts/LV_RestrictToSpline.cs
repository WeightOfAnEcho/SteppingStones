using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV_RestrictToSpline : MonoBehaviour
{
    public GameObject GO_spline;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LV_GetSplinePos getSpline = GO_spline.GetComponent<LV_GetSplinePos>();
        Vector3 splinePos = getSpline.GetSplinePosition(transform.position);
        transform.position = splinePos;
    }

}
