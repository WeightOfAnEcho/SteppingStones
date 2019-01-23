using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BT_RockMover : MonoBehaviour {

    public Camera cam;

    public GameObject Water1;
    public GameObject Water2;
    private Animator RockAnim;
    private float myProgress;

    public Text Tutorialtext3;
    bool hadTutorial3 = false;
    bool noMoreTutorials = false;


    bool stage1 = false;
    bool stage2 = false;
    bool return1 = false;
    bool return0 = false;

    private void Start()
    {
        RockAnim = gameObject.GetComponent<Animator>();
    }

    void Update()
   {
    MoveRock();
   }

    public void MakeClickable()
    {
        print("changing layer");
        gameObject.layer = LayerMask.NameToLayer("Default");
        print("new layer");

        gameObject.AddComponent<BT_Highlight_Object>();
    }


    void MoveRock()
{
if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 500))
            {
                if (hit.collider.gameObject.tag == "Stone1") //if the raycast hits the Staff tagged game object
                {


                    if (hadTutorial3 == true && noMoreTutorials == false)
                    {
                        StartCoroutine(FadeTextToZeroAlpha(1f, Tutorialtext3));
                        noMoreTutorials = true;
                    }


                }


            }
        }
    }

    void OnCollisionEnter(Collision col)
{
    if (col.gameObject.name == "Node1")
    {
        Water1.SetActive(false);
        Water2.SetActive(true);
    }

    if (col.gameObject.name == "Node2")
    {
        Water2.SetActive(false);
        Water1.SetActive(true);
    }

}

void OnCollisionExit(Collision col)
{
    if (col.gameObject.name == "Node1")
    {
        Water1.SetActive(true);

    }

    if (col.gameObject.name == "Node2")
    {
        Water2.SetActive(true);
    }

}

public void RunTutorial3()
{
    Tutorialtext3 = GameObject.Find("Tutorial3").GetComponent<Text>();

    if (hadTutorial3 == false)
    {
        StartCoroutine(FadeTextToFullAlpha(1f, Tutorialtext3));
        hadTutorial3 = true;
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
}

}
