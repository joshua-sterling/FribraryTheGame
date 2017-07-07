using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject projectileToFire;
   

    public void  shootProjectile()
    {
        GameObject projectile = (GameObject)Instantiate(projectileToFire, transform.position, Quaternion.identity);

        StartCoroutine(Waiting());

        
    }
      

    public void fightWatiTime()
    {
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
       
        yield return new WaitForSecondsRealtime(3);

        GameObject projectile2 = (GameObject)Instantiate(projectileToFire, transform.position, Quaternion.identity);
    }



}
