using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Totems : MonoBehaviour
{
    //TELEGRAPHING ----------------------------------------------------------------------------------------------------------
    private Renderer rend;

    //DOORS TO OPEN/ AFFECT -------------------------------------------------------------------------------------------------
    public GameObject doorOpen;
    public GameObject finalDoor;
    public GameObject doorDust;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }


    public void HitByWater()
    {
        rend.enabled = true;
        Instantiate(doorDust, doorOpen.transform.position, doorOpen.transform.rotation);
        doorOpen.SetActive(false);
        finalDoor.SendMessageUpwards("OpenFinalDoor", SendMessageOptions.RequireReceiver);
        
    }
}
