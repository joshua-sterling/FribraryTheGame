using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {

    private GameObject currentCollision;
    
   

    public  GameObject explosion;
    
    
  


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Projectile")
        {
            
            Debug.Log("You just got fireballed");
            Destroy(collision.gameObject);
            GameObject explode = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
            this.gameObject.GetComponent<EntityHealth>().TakeDamage();
        }
        else
        {
            Debug.Log("tag didn't work");
        }

        Debug.Log("Generic message collision occured");
    }

}
