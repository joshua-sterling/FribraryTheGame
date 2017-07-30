using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject projectileToFire;

    public bool playerTurn = true;
   

    public void  shootProjectile()
    {
        {
            Debug.Log("Fire Projectile Called");
            GameObject projectile = (GameObject)Instantiate(projectileToFire, transform.position, transform.rotation);            
           
        }
    }
      
      

   


}
