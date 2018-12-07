using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BT_Player_Controller : MonoBehaviour
{

    //RAYCASTING/ CLICK TO MOVE REFERENCES ----------------------------------------------------------------------------------------
    public Camera IsoCam; //Main camera reference for RayCasting
    private NavMeshAgent Agent; //Reference for the Agent (player)

    //PLAYER ANIMATION ------------------------------------------------------------------------------------------------------------
    Animator AdirAnim; // Reference for the Player animator attached


    //SPAWNING AND DE-SPAWNING GAME OBJECTS ----------------------------------------------------------------------------------------
    public GameObject Staff; // reference for staff gameobject in scene (for picking up)
    public GameObject AttachedStaff; //reference for attached staff (when picked up)

    public GameObject DragStone;

    public GameObject Gate1;
    public GameObject Gate2;
    public GameObject LostSoul;
    public GameObject ClickEffect; // reference for the effect when the ray cast lands a succesful hit on NavMesh
    public GameObject Water1;
    public GameObject Water2;

    public Text Tutorialtext1;
    public Text Tutorialtext2;

    public Animator LevelLoader;
    private int levelToLoad;

    bool hadTutorial1 = false;
    bool hadTutorial2 = false;
    bool hasStaff = false;


    void Start()
    {
        
        AdirAnim = GetComponent<Animator>(); // Fetch Animator component attached
        Agent = GetComponent<NavMeshAgent>(); // Fetch the Agent Properties
        StartCoroutine(FadeTextToFullAlpha(1f, Tutorialtext1));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // When the left mouse button is pressed
        {
            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition); // Fire a ray from the main camera to the click position
            RaycastHit hit; //store the resulting hit

            if (Physics.Raycast(ray, out hit, 500)) // if the hit coordiantes are on a valid collider within 500 units
            {


                if (hit.collider.gameObject.tag == "Staff") //if the raycast hits the Staff tagged game object
                {
                    print("HIT Staff");
                    Instantiate(ClickEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Agent.SetDestination(hit.point);
                   
                }


                NavMeshHit navmeshHit; // provide reference for a raycast hit on the navmesh
                int walkableMask = 1 << NavMesh.GetAreaFromName("Walkable"); // check if the nav mesh hit location was on a walkable layer/area

                if (NavMesh.SamplePosition(hit.point, out navmeshHit, 5.5f, walkableMask)) //if the ray position returns a walkable sample position                   
                {
                    print(hit.collider.gameObject.name + ", " + navmeshHit.mask);

                    NavMeshPath path = new NavMeshPath(); // create a reference for a nav mesh path
                    Agent.CalculatePath(navmeshHit.position, path); //The agent calculates a path to the hit location on nav mesh
                    Instantiate(ClickEffect, hit.point, Quaternion.LookRotation(hit.normal));//spawn the click effect at the hit location

                    if (path.status != NavMeshPathStatus.PathComplete) // if the agent calculates an impartial path
                    {
                        print("no path");

                    }

                    else if (path.status == NavMeshPathStatus.PathComplete) // if the agent calculates a full path to destination point
                    {
                        print("has path");
                        Agent.SetDestination(navmeshHit.position); // set the hit location on the nav mesh to the target destination for the agent

                        if (hadTutorial1 == false)
                        {
                            StartCoroutine(FadeTextToZeroAlpha(1f, Tutorialtext1));
                            hadTutorial1 = true;
                        }

                        if (hadTutorial1 == true && hadTutorial2 == false)
                        {
                            StartCoroutine(FadeTextToFullAlpha(1f, Tutorialtext2));
                            hadTutorial2 = true;
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
    }

   void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.gameObject.name == "Cylinder")
        {
            LostSoul.SetActive(false);
            AdirAnim.SetBool("Walking", false); //stop playing walking animation
            LoadScene(0);
        }

        if (hit.transform.gameObject.name == "pickup_Staff")
        {
            AttachedStaff.SetActive(true); // set the attached staff to active
            Staff.SetActive(false); // set the staff in the scene to false (fake picking up)
            Gate1.SetActive(false); //set the drawn gate to false
            Gate2.SetActive(true); // set the lowered gate to true
            StartCoroutine(FadeTextToZeroAlpha(1f, Tutorialtext2));
            DragStone.GetComponent<MoveAlongSpline>().MakeClickable();
            DragStone.GetComponent<MoveAlongSpline>().RunTutorial3();
        }
        
    }

    public void LoadScene(int levelIndex)
    {
        levelToLoad = levelIndex;
        LevelLoader.SetTrigger("FadeOut");

        StartCoroutine("OnFadeComplete");
    }

    IEnumerator OnFadeComplete()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelToLoad);
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
    }
}

