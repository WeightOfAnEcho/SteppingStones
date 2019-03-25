using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BT_WaterList: MonoBehaviour
{
    private static BT_WaterList lister;
    /*private static*/public List<GameObject> waterInScene = new List<GameObject>();

    //Initialising Water
    public bool waterPresent = false;
    public Transform waterStart;
    public GameObject waterBlock;

    public /*static*/ List<GameObject> getList()
    {
        //if (waterInScene == null) { waterInScene = new List<GameObject>(); }
        return waterInScene;
    }

    public /*static*/ void Add(GameObject go)
    {
        //if (waterInScene == null) { waterInScene = new List<GameObject>(); }
        waterInScene.Add(go);
    }

    public void Start()
    {
        //Instantiate(waterBlock, waterStart.position, waterStart.rotation);
        //waterPresent = true;

        if (waterInScene == null)
        {
            waterInScene = new List<GameObject>();
        }
    }

    public void TriggerWater()
    {
        if(waterPresent == true)
        {
            var lastWater = waterInScene[waterInScene.Count - 1];
            lastWater.BroadcastMessage("Regress");

            if (waterInScene.Count == 0 || waterInScene == null)
            {
                waterPresent = false; 
            }
        }

        if (waterPresent == false)
        {
            GameObject go = Instantiate(waterBlock, waterStart.position, waterStart.rotation);

            waterInScene.Add(go);
            waterPresent = true;
        }
    }
}



