﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneButtons : MonoBehaviour {

    //instance of the animator for this object
    private Animator animator;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void robotShoot()
    {
       // animator.SetTrigger("robotTrigger");
    }
}
