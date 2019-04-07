using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_FinalePT2 : MonoBehaviour
{

    public Animator finaleAnim;


    void AnimateDoor()
    {

        finaleAnim.SetBool("MonumentDone", true);
    }

    
}
