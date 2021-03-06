﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_Totems : MonoBehaviour
{
    //TELEGRAPHING ----------------------------------------------------------------------------------------------------------
    private Renderer rend;

    //DOORS TO OPEN/ AFFECT -------------------------------------------------------------------------------------------------
    public GameObject doorOpen;
    public GameObject finalDoor;
    public GameObject doorDust;


    //GEYSERS TO ACTIVATE ---------------------------------------------------------------------------------------------------
    public Animator Geyser;
    public ParticleSystem particleGeyser;
    public bool activated = false;


    public BT_Tutorial_Player tutorialPlayer;
    public BT_WaterList waterList;

    //GameObjects TO ACTIVATE ---------------------------------------------------------------------------------------------------
    public GameObject GO_one;
    public GameObject GO_two;
    public GameObject GO_NavMeshObstacle;


    // Start is called before the first frame update
    void Start()
    {
        // Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();
        rend.enabled = false; // set it to false

    }


    public void HitByWater()
    {
        rend.enabled = true;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_3"))
        {
            Instantiate(doorDust, doorOpen.transform.position, doorOpen.transform.rotation);
            doorOpen.SetActive(false);
            finalDoor.SendMessageUpwards("OpenFinalDoor", SendMessageOptions.RequireReceiver);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("AW_Level_04"))
        {
            Geyser.SetBool("GeyserMove", true);
            particleGeyser.Play();
            activated = true;

        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("01_LV"))
        {
            GO_one.SetActive(true);
            GO_NavMeshObstacle.SetActive(false);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LV_Level_05"))
        {
            //GO_one.SetActive(false);
            //GO_two.SetActive(true);
            waterList.StartCoroutine("FreezeWater");
            //GO_NavMeshObstacle.SetActive(false);
            //doorOpen.SetActive(false);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("AW_Summit_#1"))
        {
            Instantiate(doorDust, doorOpen.transform.position, doorOpen.transform.rotation);
            doorOpen.SetActive(false);
            finalDoor.SendMessageUpwards("OpenFinalDoor", SendMessageOptions.RequireReceiver);
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_0"))
        {
            tutorialPlayer.hadTutorialTotem = true;
            StartCoroutine(tutorialPlayer.FadeTextToZeroAlpha(1f, tutorialPlayer.tutorialTotem));
            tutorialPlayer.tutorialTotemParticle.Stop();
            Instantiate(doorDust, doorOpen.transform.position, doorOpen.transform.rotation);
            doorOpen.SetActive(false);
        }

    }

    public void WaterRemoved()
    {
        Geyser.SetBool("GeyserMove", false);
        particleGeyser.Stop();
        activated = false;
    }

    public void Mountainbits()
    {
        GO_NavMeshObstacle.SetActive(false);
        Instantiate(doorDust, doorOpen.transform.position, doorOpen.transform.rotation);
        doorOpen.SetActive(false);
    }
}
