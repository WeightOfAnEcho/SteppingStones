using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_FinalDoor : MonoBehaviour
{

    //DOORS IN SCENE TO BE OPENED -------------------------------------------------------------------------------------------------
    public GameObject Door1;
    public GameObject Door2;
    public GameObject doorDust; // dust effect upon deactivation
    bool allInactive = false; //boolean to check if all doors are inactive


    public void OpenFinalDoor() // function to be called each time a door is opened
    {
        if (Door1.activeInHierarchy == false && Door2.activeInHierarchy == false) // if both doors are inactive
        {
            allInactive = true;
        }


        if (allInactive)
        {
            Instantiate(doorDust, transform.position, transform.rotation);
            gameObject.SetActive(false); // 'open' final door
            
        }

    }

}
