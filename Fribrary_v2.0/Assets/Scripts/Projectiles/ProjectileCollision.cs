using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {

    private GameObject currentCollision;                            //used to track which gameobject has been collided with
    
   

    public  GameObject explosion;                                   //explostion animation
  


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ((collision.gameObject.tag == "Projectile" &&                                        //if a player projectile hits an enemy or if an enemy projectile hits the player
            this.gameObject.tag == "Enemy")||(collision.gameObject.tag ==                       //prevents the player projectile from hitting the player and vice versa with enemy
            "EnemyProjectile" && this.gameObject.tag == "Player"))
        {
            this.gameObject.GetComponent<EntityHealth>().TakeDamage();                                              //have the collided entity object take damage
            Debug.Log("You just got fireballed");
            Destroy(collision.gameObject);
            GameObject explode = (GameObject)Instantiate(explosion,                             //call explosion animation
                transform.position, Quaternion.identity);
            
        }
        else
        {
            Debug.Log("tag didn't work");
        }

        Debug.Log("Generic message collision occured");
    }

}
