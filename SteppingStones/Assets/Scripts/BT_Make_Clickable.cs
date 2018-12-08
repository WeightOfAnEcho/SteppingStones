using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Make_Clickable : MonoBehaviour {

    public void MakeClickable()
    {
        print("changing layer");
        gameObject.layer = LayerMask.NameToLayer("Default");
        print("new layer");
    }
}
