﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticles : MonoBehaviour {

    private ParticleSystem ps;                              //variable representing the particle system

	// Use this for initialization
	void Start () {
        ps = this.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!ps.isPlaying)
        {
            Destroy(this.gameObject);
        }
	}
}
