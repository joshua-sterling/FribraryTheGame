using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*This is a class of moving enemies that will be able to attack the player in the main level*/
public class AttackingMob : Entity {

    public GameObject attacking1;                   //used to ensure player object gets targeted
    public Entity attacking;                        //assign in the editor which entity this attackingmob will attack (should be player)
    public int distance;                            //how close to player should the entity get in order to attack

    private bool canAttack;                         //can this entity currently attack

	// Use this for initialization
	void Start () {
        canAttack = true;                                                           //set attack to true
        if(attacking1==null)                                                        //if attacking1 has not been assigned (or been lost between scenes)
        {
            attacking1 = GameObject.FindGameObjectWithTag("Player");                //find the player object and assign it to attacking1
            attacking = attacking1.GetComponent<Entity>();                          //then set attackign equal to the entity component, which makes the Player the target
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        /*These if statements control how the enemy "follows the player"*/
        if (attacking.GetComponent<Rigidbody2D>().transform.position.y > ((GetComponent<Rigidbody2D>().transform.position.y) + distance))       //if the target is above this attackign mob, move up
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.up * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.y < ((GetComponent<Rigidbody2D>().transform.position.y) - distance))       //if the target is below this attackign mob, move down
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.down * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.x > ((GetComponent<Rigidbody2D>().transform.position.x) + distance))       //if the target is right of this attackign mob, move right
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.x < ((GetComponent<Rigidbody2D>().transform.position.x) - distance))       //if the target is left of this attackign mob, move left
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * Time.deltaTime;
        }
        if(Vector2.Distance(GetComponent<Rigidbody2D>().transform.position, attacking.transform.position) <= distance)                          //if attackign mob is within attack range, attack
        {
            attackEntity();                                                                                                                     //call attack function
            StartCoroutine(waitForAttack());                                                                                                    //call wait function before seeing if it can attack again
        }
        
        if (health <= 0)                                                                                                                    //if unit health drops, it dies
        {
            Die();
        }
    }

    public void Die() { /*this type of attack will be used in future functionality*/}

    /*This function controls the damage done to the target*/
    public void attackEntity()
    {
        int damage = Random.Range(1, 20);                       //set damage amount to integer between 1 and 20
        attacking.damageEntity(damage);                         //call the damage function
    }

    IEnumerator waitForAttack()                     //can only attack every 2 seconds
    {
        canAttack = false;                          //disable attack
        yield return new WaitForSeconds(2);         //in this function wait for 2 seconds
        canAttack = true;                           //re-enable attack

    }
}
