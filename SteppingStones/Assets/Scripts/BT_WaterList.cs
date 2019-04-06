﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_WaterList: MonoBehaviour
{
    private static BT_WaterList lister;
    /*private static*/public List<GameObject> waterInScene = new List<GameObject>();

    //Initialising Water
    public bool waterPresent = false;
    public Transform waterStart;
    public GameObject waterBlock;


    //buttons
    public GameObject FlowButton;
    public GameObject UnFlowButton;

    //totems
    public BT_Totems[] totems;

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
        //if (waterPresent == true)
        //{
        //    var lastWater = waterInScene[waterInScene.Count - 1];
        //    lastWater.BroadcastMessage("Regress");

        //    RemoveAllWater();


        //}

            GameObject go = Instantiate(waterBlock, waterStart.position, waterStart.rotation);
            waterInScene.Add(go);
        FlowButton.SetActive(false);
        UnFlowButton.SetActive(true);
    }

    public void RemoveAllWater()
    {

        for (int i = 0; i < waterInScene.Count; i++)
        {

            GameObject.Destroy(waterInScene[i]);
        }



        FlowButton.SetActive(true);
        UnFlowButton.SetActive(false);

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("AW_Level_04"))
        {
            for (int i = 0; i < totems.Length; i++)
            {

                totems[i].WaterRemoved();
            }
            
        }
    }
}



