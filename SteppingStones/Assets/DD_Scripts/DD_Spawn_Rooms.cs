using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Spawn_Rooms : MonoBehaviour
{
    public GameObject[] gos_rooms;
    public int in_size = 5;
    public float fl_spacing = 10;
    public Vector3 v3_rotation = new Vector3(270, 0, 0);

    public Transform tx_start_position;
    private Vector3 v3_spawn_pos;

    // Use this for initialization
    void Start()
    {
        v3_spawn_pos = tx_start_position.position;
        SpawnRooms();
    }//------


    //-----------------------------------------------------------------
    void SpawnRooms()
    {
        /// Rows
        for (int _rows = 0; _rows < in_size; _rows++)
        {   // Cols
            for (int _cols = 0; _cols < in_size; _cols++)
            {
                int _index = Random.Range(0, gos_rooms.Length);

                Instantiate(gos_rooms[_index], new Vector3(v3_spawn_pos.x + _cols * fl_spacing, v3_spawn_pos.y, v3_spawn_pos.z + _rows * -fl_spacing), Quaternion.Euler(v3_rotation));
            }
        }
    }//----------

}//==========

