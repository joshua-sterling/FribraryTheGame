using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {

    private GameObject currentCollision;
    
   

    public  GameObject explosion;
    
    
  


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ((collision.gameObject.tag == "Projectile" && this.gameObject.tag == "Enemy")||(collision.gameObject.tag == "EnemyProjectile" && this.gameObject.tag == "Player"))
        {
            this.gameObject.GetComponent<EntityHealth>().TakeDamage();
            Debug.Log("You just got fireballed");
            Destroy(collision.gameObject);
            GameObject explode = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
            
        }
        else
        {
            Debug.Log("tag didn't work");
        }

        Debug.Log("Generic message collision occured");
    }

}
