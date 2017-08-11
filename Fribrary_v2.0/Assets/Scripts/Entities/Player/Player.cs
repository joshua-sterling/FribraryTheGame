using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*The player class represents the player and inherits from Entity*/
public class Player : Entity {

    
    private float currentHealth, maxHealth;                                             //for tracking current health and maximum health

    public Slider healthbar;                                                            //assign a slider in the editor to act as a healthbar
     

    //these bools control parameters on the player animation transitions
    bool walkLeft = false, 
        walkRight = false, 
        walkUp = false, 
        walkDown = false, 
        playerIdle = false;

   
    //instance of the animator for this object - allows for control of the animations
    private Animator animator;   

        
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();                                            //assign the animator for this game object

        currentHealth = GameController.controller.playerCurrentHealth;                  //get current health from the game controller singleton
        maxHealth = GameController.controller.playerMaxHealth;                          //get the maximum health from the game controller
        
        healthbar.value = calculateHealth();                                            //set the healthbar value
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
            playerIdle = true;                                      //player is not moving, run idle animation
        }
        else
        {
            playerIdle = false;                                     //player is moving, stop the idle animation
        }
        
        animator.SetBool("WalkDown", walkDown);                 //call animation parameters to trigger appropriate animation
        animator.SetBool("WalkRight", walkRight);
        animator.SetBool("WalkUp", walkUp);
        animator.SetBool("WalkLeft", walkLeft);
        animator.SetBool("PlayerIdle", playerIdle);

        //Actual player movement on the screen - distance moved controlled by speed variable, which is inherited from Entity
        if (!GameController.controller.messagePanelActive)      //only allow movement when message panel is not active
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))                                                       //move player up
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))                                                     //move player down
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))                                                     //move player left
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))                                                    //move player right
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }

        if (currentHealth <= 0)             //see if the player died
        {
            Die();
        }

    }

    public void Die() { print("Well, crap."); }                     //In the prototype, the player cannot die on the main level
      
    //calculate health for the slider, which needs health from 0 to 1.00
    public float calculateHealth()
    {
        float health = currentHealth / maxHealth;                   //health is the percent of current divided by max
        return health;
    }

  

}
