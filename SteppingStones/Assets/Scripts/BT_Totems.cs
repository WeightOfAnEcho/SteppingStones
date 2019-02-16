using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Totems : MonoBehaviour
{
    private Renderer rend;
    public GameObject doorOpen;
    public GameObject finalDoor;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();
        rend.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitByWater()
    {
        rend.enabled = true;
        doorOpen.SetActive(false);
        finalDoor.SendMessageUpwards("OpenFinalDoor", SendMessageOptions.RequireReceiver);
    }
}
