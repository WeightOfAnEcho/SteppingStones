﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShadervalues : MonoBehaviour
{

    MaterialPropertyBlock props;
    [SerializeField]
    Transform target;
    float value = 0;
    [SerializeField]
    float appearSpeed = 10f;
    [SerializeField]
    float disappearSpeed = 5f;
    [SerializeField]
    float radius = 12f;
    [SerializeField]
    bool keep = false;

    [SerializeField]
    MeshRenderer[] objects;
    [SerializeField]
    float[] values;

    public AudioClip stoneSlide;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        props = new MaterialPropertyBlock();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetPropertyBlock(props);
        }
        values = new float[objects.Length];

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (Vector3.Distance(objects[i].transform.position, target.position) < radius)
            {
                values[i] = Mathf.Lerp(values[i], 1, Time.deltaTime * appearSpeed);
                
            }
            else if (!keep)
            {
                values[i] = Mathf.Lerp(values[i], 0, Time.deltaTime * disappearSpeed);
            }
            props.SetFloat("_Moved", values[i]);
            objects[i].SetPropertyBlock(props);
        }


    }
}
