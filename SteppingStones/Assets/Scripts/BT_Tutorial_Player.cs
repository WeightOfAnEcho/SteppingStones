using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BT_Tutorial_Player : BT_Player_Base
{

    public Text tutorialClick;
    public Text tutorialFlow;
    public Text tutorialTotem;
    public Text tutorialSoul;

    public ParticleSystem tutorialClickParticle;
    public ParticleSystem tutorialFlowParticle;
    public ParticleSystem tutorialTotemParticle;
    public ParticleSystem tutorialSoulParticle;


    public bool hadTutorialClick;
    public bool hadTutorialFlow;
    public bool hadTutorialTotem;
    public bool hadTutorialSoul;
    private bool fireOnce;

    public GameObject flowButton;
    public BT_WaterList check;

    //This exists incase any edits to player base is required -------------------------------------------------------------------------------------------------
    protected override void Awake()
    {
        base.Awake(); // start base functionality heled in BT_Player_Base
        hadTutorialClick = false;
        TutorialClick();
    }

    void TutorialClick()
    {
        //tutorialClick = GameObject.Find("Tutorial_Click").GetComponent<Text>();

        if(hadTutorialClick == false)
        {
            StartCoroutine(FadeTextToFullAlpha(1f, tutorialClick));
        }
    }

    void TutorialFlow()
    {
        if (hadTutorialClick == true && hadTutorialFlow == false)
        {
            StartCoroutine(FadeTextToFullAlpha(1f, tutorialFlow));
            tutorialFlowParticle.Play();
            flowButton.SetActive(true);
        }
    }

    void TutorialTotem()
    {
        if (hadTutorialFlow == true && hadTutorialTotem == false)
        {
            StartCoroutine(FadeTextToFullAlpha(1f, tutorialTotem));
            tutorialTotemParticle.Play();
        }
    }

    void TutorialSoul()
    {
        if (hadTutorialTotem == true && hadTutorialSoul == false)
        {
            StartCoroutine(FadeTextToFullAlpha(1f, tutorialSoul));
            tutorialSoulParticle.Play();
        }
    }

    protected override void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownBoolean == false) // When the left mouse button is pressed
        {


            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition); // Fire a ray from the main camera to the click position
            RaycastHit hit; //store the resulting hit

            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // if the hit coordiantes are on a valid collider within 500 units
            {

                NavMeshHit navmeshHit; // provide reference for a raycast hit on the navmesh
                int walkableMask = 1 << NavMesh.GetAreaFromName("Walkable"); // check if the nav mesh hit location was on a walkable layer/area

                if (NavMesh.SamplePosition(hit.point, out navmeshHit, 5.5f, walkableMask)) //if the ray position returns a walkable sample position                   
                {
                    //print(hit.collider.gameObject.name + ", " + navmeshHit.mask); //uncomment if you require to know what the raycast is hitting for debugging

                    NavMeshPath path = new NavMeshPath(); // create a reference for a nav mesh path
                    Agent.CalculatePath(navmeshHit.position, path); //The agent calculates a path to the hit location on nav mesh


                    if (path.status == NavMeshPathStatus.PathPartial || path.status == NavMeshPathStatus.PathInvalid) // if the agent calculates an impartial path
                    {
                        print("no path");

                    }

                    else if (path.status == NavMeshPathStatus.PathComplete) // if the agent calculates a full path to destination point
                    {
                        print("has path");
                        Agent.SetDestination(navmeshHit.position); // set the hit location on the nav mesh to the target destination for the agent
                        Instantiate(ClickEffect, hit.point, Quaternion.LookRotation(hit.normal));//spawn the click effect at the hit location

                        if (hadTutorialClick == false)
                        {
                            hadTutorialClick = true;
                            StartCoroutine(FadeTextToZeroAlpha(1f, tutorialClick));
                            tutorialClickParticle.Stop();
                            
                        }
                    }
                }

            }

        }

        // ANIMATION CONTROLLING BASED ON DISTANCE FROM TARGET DESTINATION -----------------------------------------------------------------------------

        if (Agent.remainingDistance > Agent.stoppingDistance) // If remaining distance on path is greater than stopping distance
        {
            AdirAnim.SetBool("Walking", true); // play walking animation
        }

        else
        {
            AdirAnim.SetBool("Walking", false); //stop playing walking animation
        }

        //Tutorial checks

        if (check.waterPresent == true && fireOnce == false)
        {
            fireOnce = true;
            hadTutorialFlow = true;
            StartCoroutine(FadeTextToZeroAlpha(1f, tutorialFlow));
            tutorialFlowParticle.Stop();

        }
    }




    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }

        if(hadTutorialClick == true && hadTutorialFlow == false)
        {
            TutorialFlow();
        }

        if(hadTutorialFlow == true && hadTutorialTotem == false)
        {
            TutorialTotem();
        }

        if (hadTutorialTotem == true && hadTutorialSoul == false)
        {
            TutorialSoul();
        }
    }
}
