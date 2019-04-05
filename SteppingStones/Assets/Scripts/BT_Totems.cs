using System.Collections;
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

        }




        }
}
