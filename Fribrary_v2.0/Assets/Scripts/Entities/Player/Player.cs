﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    public int direction;

    //change the player graphic to face the correct direction
    public Sprite down;
    public Sprite up;
    public Sprite right;
    public Sprite left;

    //these bools contorl parameters on the player animation transitions
    bool walkLeft = false, walkRight = false, walkUp = false, walkDown = false, playerIdle = false;

    public SpriteRenderer spriteParent;

    //instance of the animator for this object
    private Animator animator;   

    //creates an inventory instance for the player
    public List<Item> inventory = new List<Item>();
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        walkRight = Input.GetKey(KeyCode.D);                //if D is pressed, set walk right true
        walkDown = Input.GetKey(KeyCode.S);                 //is S is pressed, set walk down true
        walkUp = Input.GetKey(KeyCode.W);                   //if W is pressed, set walk up true
        walkLeft = Input.GetKey(KeyCode.A);                 //if A is pressed, set walk left true

        if(!walkRight && !walkDown && !walkUp && !walkLeft)         //if A,S,W,D not pressed call idle animation
        {
            playerIdle = true;
        }
        else
        {
            playerIdle = false;
        }
        
        animator.SetBool("WalkDown", walkDown);                 //call animation parameters to trigger appropriate animation
        animator.SetBool("WalkRight", walkRight);
        animator.SetBool("WalkUp", walkUp);
        animator.SetBool("WalkLeft", walkLeft);
        animator.SetBool("PlayerIdle", playerIdle);

        //Actual player movement on the screen
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
           
            GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
            direction = 1;     
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            
            GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
            direction = 0;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
            direction = 2;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
            direction = 3;
        }
        




        if (direction == 0)
        {
            spriteParent.sprite = down;
        }
        if (direction == 1)
        {
            spriteParent.sprite = up;
        }
        if (direction == 2)
        {
            spriteParent.sprite = left;
        }
        if (direction == 3)
        {
            spriteParent.sprite = right;
        }

        if (health <= 0)
        {
            Die();
        }

    }

    public void Die() { print("Well, crap."); }

    public void changeDirection()
    {

    }

   

}
