using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed = 3f;
    public int direction = 1;               //1 = left, 2 = right

    Transform t;        //caches the image

    private void Awake()
    {
        t = transform;
    }

    private void Update()
    {
        if (direction == 1)
        { t.Translate(Vector2.left * speed * Time.deltaTime); }       //delta time normalizes movement over framerate
        else
        { t.Translate(Vector2.right * speed * Time.deltaTime); }
    }


}
