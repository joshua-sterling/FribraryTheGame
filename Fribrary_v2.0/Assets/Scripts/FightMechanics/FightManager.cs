using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour {

    public static FightManager fm;                                                  //singleton fightmanager instance

    public FireProjectile enemyFire;                                                //public variable to determine what projectile will be fired by enemy
    public FireProjectile playerFire;                                               //public variable to determine what projectile will be fired by player
    public Button attackbutton;                                                     //button used by player to attack
    public GameObject[] collectables;                                               //array of gameobjects 

    public GameObject player, enemy;

    //instance of the animator for this object
    public Animator animator;

    bool enemyTurn = false;                     //is it the enemy's turn
    bool playerTurn = false;
      

	// Use this for initialization
	void Start () {
        playerTurn = true;
        attackbutton.interactable = true;

        collectables = GameObject.FindGameObjectsWithTag("Collectable");            //create an array of every active collectable object
        foreach(GameObject coll in collectables)
        {
            coll.SetActive(false);                                                  //set them all inactive as they do not need to show on the fightscene
        }


    }
	
	// Update is called once per frame
	void Update () {
		
        if(enemyTurn)
        {            
            enemyAttack();                                                          //call the enemy attack function
        }

	}

    public void enemyAttack()
    {
        if (enemyTurn && !enemy.gameObject.GetComponent<EntityHealth>().dead)       //see if it is the enemy's turn and if they are still alive
        {
            Debug.Log("Unity thinks the enemy is dead?");
            Debug.Log(enemy.gameObject.GetComponent<EntityHealth>().dead);
            enemyTurn = false;
           
            StartCoroutine(Waiting());                                              //call the wait routine

            playerTurn = true;                                                      //enemy turn over, now player's turn
            
        }
       
    }
    
    public void playerAttack()
    {
        if (playerTurn)
        {
            playerFire.shootProjectile();                                           //fire the designated player projectile
           
            playerTurn = false;                                                     //player turn over
            enemyTurn = true;                                                       //now enemy turn
           
        }
    }

    IEnumerator Waiting()
    {
        attackbutton.interactable = false;                  //disable attack button for player
        yield return new WaitForSecondsRealtime(3);         //wait 3 seconds
        Debug.Log("EnemyShooting");
        Debug.Log("Unity thinks the enemy is dead?");
        Debug.Log(enemy.gameObject.GetComponent<EntityHealth>().dead);
        if (!enemy.gameObject.GetComponent<EntityHealth>().dead)
        {
            animator.SetTrigger("robotTrigger");
            yield return new WaitForSecondsRealtime(1);
            enemyFire.shootProjectile();
        }                        //enemy attack
        yield return new WaitForSecondsRealtime(3);         //wait 3 seconds
        attackbutton.interactable = true;                   //enable attack button for player
    }




}
