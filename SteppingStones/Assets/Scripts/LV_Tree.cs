﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV_Tree : MonoBehaviour
{
    public GameObject NavMeshBlock;
    Animator tree_anim;
    int hitCount = 0;
    public int hitsUntilKnock = 2;
    public GameObject dustPoof;

    private void Awake()
    {
        tree_anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT");
        Instantiate(dustPoof, other.transform.position, other.transform.rotation);

        if (hitCount < hitsUntilKnock)
        {
            hitCount++;

        }
        else
        {
            KnockTree();

        }
    }


    void KnockTree()
    {
        tree_anim.SetTrigger("knockTree");
        NavMeshBlock.SetActive(false);
    }
    
}
