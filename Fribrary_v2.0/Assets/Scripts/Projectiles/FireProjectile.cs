﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

    public GameObject projectileToFire;

    public void  shootProjectile()
    {
        GameObject projectile = (GameObject)Instantiate(projectileToFire, transform.position, Quaternion.identity);
    }


}