using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*This class manages the fight scene*/
public class FightManager : MonoBehaviour {

    public static FightManager fm;                                                  //singleton fightmanager instance

    public FireProjectile enemyFire;                                                //public variable to determine what projectile will be fired by enemy
    public FireProjectile playerFire;                                               //public variable to determine what projectile will be fired by player
    public Button attackbutton;                                                     //button used by player to attack
    public GameObject[] collectables;                                               //array of gameobjects 

    public GameObject player, enemy;                                                //allows the game objects to be assigned in the editor

    //instance of the animator for this object
    public Animator animator;

    bool enemyTurn = false;                                                         //is it the enemy's turn
    bool playerTurn = false;                                                        //is it the player's turn
      

	// Use this for initialization
	void Start () {
        playerTurn = true;                                                          //always starts as the player's turn
        attackbutton.interactable = true;                                           //enable the attack button

        collectables = GameObject.FindGameObjectsWithTag("Collectable");            //create an array of every active collectable object
        foreach(GameObject coll in collectables)
        {
            coll.SetActive(false);                                                  //set them all inactive as they do not need to show on the fightscene
        }


    }
	
	// Update is called once per frame
	void Update () {
		
        if(enemyTurn)                                                               //check to see if it is the enemy's turn
        {            
            enemyAttack();                                                          //call the enemy attack function
        }

	}

    /*This function controls the enemy attack*/
    public void enemyAttack()
    {
        if (enemyTurn && !enemy.gameObject.GetComponent<EntityHealth>().dead)       //see if it is the enemy's turn and if they are still alive
        {
            enemyTurn = false;
            StartCoroutine(TimedAttack());                                              //call the wait routine
            playerTurn = true;                                                      //enemy turn over, now player's turn            
        }
       
    }
    
    /*This function controls the player attack*/
    public void playerAttack()
    {
        if (playerTurn)                                                             //see if it is the player's turn
        {
            playerFire.shootProjectile();                                           //fire the designated player projectile
           
            playerTurn = false;                                                     //player turn over
            enemyTurn = true;                                                       //now enemy turn
           
        }
    }

    /* This function timest the enemy attack so that there is a pause before
     * and after to allow the animations to complete before it becomes the player's turn*/
    IEnumerator TimedAttack()
    {
        attackbutton.interactable = false;                  //disable attack button for player
        yield return new WaitForSecondsRealtime(3);         //wait 3 seconds
        
        if (!enemy.gameObject.GetComponent<EntityHealth>().dead)            //only complete the attack if the enemy is not dead
        {
            animator.SetTrigger("robotTrigger");                            //call the enemy attack animation
            yield return new WaitForSecondsRealtime(1);                     //wait 1 second
            enemyFire.shootProjectile();                                    //call the projectile 
        }                        //enemy attack
        yield return new WaitForSecondsRealtime(3);         //wait 3 seconds
        attackbutton.interactable = true;                   //enable attack button for player
    }




}
