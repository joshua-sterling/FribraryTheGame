using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour {

    public static FightManager fm;

    public FireProjectile enemyFire;
    public FireProjectile playerFire;
    public Button attackbutton;

    public GameObject player, enemy;


    bool enemyTurn = false;                     //is it the enemy's turn
    bool playerTurn = false;
      

	// Use this for initialization
	void Start () {
        playerTurn = true;
        attackbutton.interactable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(enemyTurn)
        {            
            enemyAttack();
        }

	}

    public void enemyAttack()
    {
        if (enemyTurn && !enemy.gameObject.GetComponent<EntityHealth>().dead)
        {
            Debug.Log("Unity thinks the enemy is dead?");
            Debug.Log(enemy.gameObject.GetComponent<EntityHealth>().dead);
            enemyTurn = false;
           
            StartCoroutine(Waiting());

            playerTurn = true;
            
        }
       
    }
    
    public void playerAttack()
    {
        if (playerTurn)
        {
            playerFire.shootProjectile();
           
            playerTurn = false;           
            enemyTurn = true;
           
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
        { enemyFire.shootProjectile(); }                        //enemy attack
        yield return new WaitForSecondsRealtime(3);         //wait 3 seconds
        attackbutton.interactable = true;                   //enable attack button for player
    }




}
