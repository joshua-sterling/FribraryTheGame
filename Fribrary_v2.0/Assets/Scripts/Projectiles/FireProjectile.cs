using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class controls creating an instance of a projectile to be fired*/
public class FireProjectile : MonoBehaviour {

    public GameObject projectileToFire;                 //assign the projectile to be fired in the editor
                
    public Transform playercore;                            //set a position for the projectile to fire from - assign in editor
   
    //shoot projectile creates an instance of a projectile 
    public void  shootProjectile()
    {
        {
            GameObject projectile = (GameObject)Instantiate(projectileToFire, playercore.position, Quaternion.identity);            
        }
    }
      
      

   


}
