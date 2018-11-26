using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stones : MonoBehaviour
{
    
    private Animator Stones_Anim;
    public GameObject StartFlow;
    public GameObject ChangedFlow;
    public GameObject Link;

    // Use this for initialization
    void Start()
    {

        Stones_Anim = GetComponent<Animator>();

    }

    void HitByRay()
    {
        Stones_Anim.SetBool("MoveStones", true);
        StartFlow.SetActive(false);
        ChangedFlow.SetActive(true);
        Link.SetActive(true);
    }
}
