using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour {

    public static FightManager fm;

    public FireProjectile enemyFire;
    public FireProjectile playerFire;

    bool enemyTurn = false;                     //is it the enemy's turn
    bool playerTurn = false;

	// Use this for initialization
	void Start () {
        playerTurn = true;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(enemyTurn) { enemyAttack(); }

	}

    public void enemyAttack()
    {
        if (enemyTurn)
        {
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

        yield return new WaitForSecondsRealtime(3);
        enemyFire.shootProjectile();
    }




}
