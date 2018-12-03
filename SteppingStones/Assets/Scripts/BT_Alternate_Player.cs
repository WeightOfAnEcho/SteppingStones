using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BT_Alternate_Player : MonoBehaviour {

    [SerializeField] private float moveSpeed = 4f;
    Vector3 forward, right;
    public Camera IsoCam;
    private CharacterController cc;
    private Animator AdyrAnim;

    public GameObject Staff; // reference for staff gameobject in scene (for picking up)
    public GameObject AttachedStaff; //reference for attached staff (when picked up)
    public GameObject Stone1;
    public GameObject Stone2;
    public GameObject Stone3;
    public GameObject Stone4;
    public GameObject Gate1;
    public GameObject Gate2;
    public GameObject LostSoul;
    public GameObject ClickEffect; // reference for the effect when the ray cast lands a succesful hit on NavMesh
    public GameObject Water1;
    public GameObject Water2;
    public GameObject TutorialGuide1;
    public GameObject TutorialGuide2;

    public Animator TutorialAnim;
    public Animator LevelLoader;
    private int levelToLoad;

    // Use this for initialization
    void Start ()
    {
        cc = GetComponent<CharacterController>();
        AdyrAnim = GetComponent < Animator > ();

        forward = IsoCam.transform.forward; // set forward vector to equal camera's forward vector
        forward.y = 0; //ensure our y value always set to 0
        forward = Vector3.Normalize(forward); //making sure the vector is set to 1 for motion
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

    }

    // Update is called once per frame
    void Update()
    {



        AdyrAnim.SetBool("Walking", false);

        if (Input.anyKey) // although any key declared, only WASD assigned the values necessary
        {
            Move(); // move the player
        }

        if (Input.GetMouseButtonDown(0)) // When the left mouse button is pressed
        {
            Ray ray = IsoCam.ScreenPointToRay(Input.mousePosition); // Fire a ray from the main camera to the click position
            RaycastHit hit; //store the resulting hit

            if (Physics.Raycast(ray, out hit, 500)) // if the hit coordiantes are on a valid collider within 500 units
            {

                if (hit.collider.gameObject.tag == "Staff") //if the raycast hits the Staff tagged game object
                {
                    print("HIT Staff");

                    TutorialGuide1.SetActive(false);
                    AttachedStaff.SetActive(true); // set the attached staff to active
                    Staff.SetActive(false); // set the staff in the scene to false (fake picking up)
                    Gate1.SetActive(false); //set the drawn gate to false
                    Gate2.SetActive(true); // set the lowered gate to true
                    Stone1.GetComponent<BT_Drag>().MakeClickable();
                    StartCoroutine("Tutorial2");
                }



                if (hit.collider.gameObject.tag == "Stone1") //if the raycast hits the Stone 1 game object
                {

                    Stone1.SetActive(false);
                    Stone2.SetActive(true);
                    Water1.SetActive(false);
                    TutorialGuide2.SetActive(false);
                }

                if (hit.collider.gameObject.tag == "Stone2") //if the raycast hits the Stone 2 game object
                {

                    Stone2.SetActive(false);
                    Stone3.SetActive(true);
                    Water1.SetActive(true);
                    Water2.SetActive(false);

                }
                if (hit.collider.gameObject.tag == "Stone3") //if the raycast hits the Stone 3 game object
                {

                    Stone3.SetActive(false);
                    Stone4.SetActive(true);
                    Water2.SetActive(true);

                }

                if (hit.collider.gameObject.tag == "Stone4") //if the raycast hits the Stone 4 game object
                {

                    Stone1.SetActive(true);
                    Stone4.SetActive(false);


                }
            }
        }
    }

    void Move()
    {
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // new direction equals values specified in input manager
        //THIS CODE EXISTS TO ENABLE MOBILE INPUT COMMANDS


        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement); //combines and normalises above movment to allow player to have a heading during movement

        GetComponent<CharacterController>().SimpleMove(heading * moveSpeed);

        transform.forward = heading; // sets the rotation of the player to be where the input Vector3 dictates

        AdyrAnim.SetBool("Walking", true);
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.gameObject.name == "Cylinder")
        {
            LostSoul.SetActive(false);
            LoadScene(0);
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

    IEnumerator Tutorial1()
    {
        yield return new WaitForSeconds(5);
        TutorialGuide1.SetActive(true);
    }

    IEnumerator Tutorial2()
    {
        yield return new WaitForSeconds(5);
        TutorialGuide2.SetActive(true);
        TutorialAnim.SetTrigger("Tutorial2");
    }

}
