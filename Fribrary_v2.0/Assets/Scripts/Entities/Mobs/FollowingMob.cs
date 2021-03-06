﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Following Mob class creates an enemy that will follow the player around the level*/
public class FollowingMob : Entity {

    private GameObject following;                //create an instance of entity that is being followed
    public float distance;                  //distance to stay away from player

    


    void Start () {
        following = GameObject.FindGameObjectWithTag("Player");                                             //set the target to follow to be teh player
    }
	
	// Update is called once per frame
	void Update () {

        if (!GameController.controller.messagePanelActive)      //only allow movement when message panel is not active
        {
            if (following.GetComponent<Rigidbody2D>().transform.position.y >                                 //if following is higher, move up
                ((GetComponent<Rigidbody2D>().transform.position.y) + distance))
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (following.GetComponent<Rigidbody2D>().transform.position.y <                                //if following is lower move down
                ((GetComponent<Rigidbody2D>().transform.position.y) - distance))
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
            }
            if (following.GetComponent<Rigidbody2D>().transform.position.x >                                //if following is right, move right
                ((GetComponent<Rigidbody2D>().transform.position.x) + distance))
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (following.GetComponent<Rigidbody2D>().transform.position.x <                                //if following is left, move left
                ((GetComponent<Rigidbody2D>().transform.position.x) - distance))
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }       
        
    }
   
}
