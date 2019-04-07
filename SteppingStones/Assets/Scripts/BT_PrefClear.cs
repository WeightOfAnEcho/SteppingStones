using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_PrefClear : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
