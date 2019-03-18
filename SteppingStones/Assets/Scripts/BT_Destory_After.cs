using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Destory_After : MonoBehaviour {

    public float waitTime;

	// Use this for initialization
	void Start () {

        Destroy(gameObject, waitTime);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
