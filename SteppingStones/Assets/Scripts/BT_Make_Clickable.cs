using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Make_Clickable : MonoBehaviour {

    Collider col;

    public void MakeClickable()
    {
        print("changing layer");
        gameObject.layer = LayerMask.NameToLayer("Default");
        print("new layer");
        col = GetComponentInChildren<Collider>();
        col.enabled = col.enabled;

    }
}
