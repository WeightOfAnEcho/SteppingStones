using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Totems : MonoBehaviour
{
    public Renderer rend;

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
    }
}
