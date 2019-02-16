using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_FinalDoor : MonoBehaviour
{


    public GameObject Door1;
    public GameObject Door2;
    public GameObject Puzzle;
    bool allInactive = false; //boolean to check if all doors are inactive


    public void OpenFinalDoor() // function to be called each time a door is opened
    {
        if (Door1.activeInHierarchy == false && Door2.activeInHierarchy == false) // if both doors are inactive
        {
            allInactive = true;
        }


        if (allInactive)
        {
            gameObject.SetActive(false); // 'open' final door
            Puzzle.layer = 2;
        }

    }

}
