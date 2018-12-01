﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class BT_Drag : MonoBehaviour
{
    public Camera IsoCam;

    void Start()
    {
        gameObject.layer = 2;
    }

    void Update()
    {

    }

    public void MakeClickable()
    {
        print("changing layer");
        gameObject.layer = 2;
    }

    public void OnMouseDrag()
    {

        Vector3 point = IsoCam.ScreenToWorldPoint(Input.mousePosition);
        point.x = Mathf.Clamp(point.x, -44f, 27f);
        point.y = transform.position.y;
        point.z = transform.position.z;
        transform.position = point;

        //float distance_to_screen = IsoCam.WorldToScreenPoint(gameObject.transform.position).z;
        //Vector3 pos_move = IsoCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        //transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);

    }


}

