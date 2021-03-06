﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_Ancient_Lang : MonoBehaviour
{
    private Renderer[] rends;
    public Material mouseOverColor;
    public Material originalColor;
    public ParticleSystem glow;

    public BT_Pauser pauseGame;

    public BT_Tutorial_Player tutorialPlayer;
    public AncientLangCheck ALC;

    [SerializeField]
     private float range = 10.0f;

    private Transform t;
    private Transform player;


    private void Awake()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Fetch the Renderer from the GameObject
        rends = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Vector3.Distance(transform.position, player.position) < range)
        {
            Glow();

            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    // whatever tag you are looking for on your game object
                    if (hit.collider.tag == "Lang")
                    {

                        Scene currentScene = SceneManager.GetActiveScene(); // Create a temporary reference to the current scene.
                        string sceneName = currentScene.name;

                        if (sceneName == "Level_0") // if tutorial
                        {
                            tutorialPlayer.hadTutorialLang = true;
                            StartCoroutine(tutorialPlayer.FadeTextToZeroAlpha(1f, tutorialPlayer.tutorialLang));
                            tutorialPlayer.tutorialLangParticle.Stop();
                            StartCoroutine(WaitFor(1));
                            PlayerPrefs.SetInt("EngBatch01", 1); // set the correct batch to be translated
                            UpdatePrefs(); // call function to update prefs
                        }

                        if (sceneName == "01_LV") // if beach
                        {
                            StartCoroutine(WaitFor(1));
                            PlayerPrefs.SetInt("EngBatch02", 1); // set the correct batch to be translated
                            UpdatePrefs(); // call function to update prefs
                            pauseGame.Pause();
                        }

                        if (sceneName == "Level_3") // if beach
                        {
                            StartCoroutine(WaitFor(1));
                            PlayerPrefs.SetInt("EngBatch03", 1); // set the correct batch to be translated
                            UpdatePrefs(); // call function to update prefs
                            pauseGame.Pause();
                        }

                        if (sceneName == "AW_Level_04") // if beach
                        {
                            StartCoroutine(WaitFor(1));
                            PlayerPrefs.SetInt("EngBatch04", 1); // set the correct batch to be translated
                            UpdatePrefs(); // call function to update prefs
                            pauseGame.Pause();
                        }

                        if (sceneName == "LV_Level_05") // if beach
                        {
                            StartCoroutine(WaitFor(1));
                            PlayerPrefs.SetInt("EngBatch05", 1); // set the correct batch to be translated
                            UpdatePrefs(); // call function to update prefs
                            pauseGame.Pause();
                        }

                        if (sceneName == "AW_Summit_#1") // if beach
                        {
                            StartCoroutine(WaitFor(1));
                            PlayerPrefs.SetInt("EngBatch06", 1); // set the correct batch to be translated
                            UpdatePrefs(); // call function to update prefs
                            pauseGame.Pause();
                        }
                    }
                }
            }
        }

        else if (Vector3.Distance(transform.position, player.position) > 10)
        {
            StopGlow();
        }
    }


    void Glow()
    {
        glow.Play();
        foreach (Renderer rend in rends)
        {
            rend.material = mouseOverColor;
        }
       
    }

    void StopGlow()
    {
        glow.Stop();

        foreach (Renderer rend in rends)
        {
            rend.material = originalColor;
        }

    }


    IEnumerator WaitFor(int seconds) // delay coroutine for number of seconds delay
    {
        yield return new WaitForSeconds(seconds);
        glow.Stop();
        gameObject.SetActive(false);
    }

    void UpdatePrefs()
    {
        
        ALC.RefreshPrefs(); // referesh all prefs
    }
}
