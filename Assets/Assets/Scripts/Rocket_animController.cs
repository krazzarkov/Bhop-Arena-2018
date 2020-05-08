﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_animController : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("rocket_anim");
        }
    }
}