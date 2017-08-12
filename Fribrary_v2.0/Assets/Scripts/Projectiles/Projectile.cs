using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This clas defines the projectile to be created*/
public class Projectile : MonoBehaviour {
    public float speed = 3f;                //determines how fast the projectile moves
    public int direction = 1;               //1 = left, 2 = right determines projectile direction on teh screen

    Transform t;        //caches the image

    private void Awake()
    {
        t = transform;
    }

    /*on update move the projectile in the appropriate direction*/
    private void Update()
    {
        if (direction == 1)
        { t.Translate(Vector2.left * speed * Time.deltaTime); }       //delta time normalizes movement over framerate
        else
        { t.Translate(Vector2.right * speed * Time.deltaTime); }
    }


}
