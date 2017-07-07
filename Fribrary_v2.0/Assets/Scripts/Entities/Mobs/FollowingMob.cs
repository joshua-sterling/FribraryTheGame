using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingMob : Entity {

    public Entity following;                //create an instance of entity that is being followed
    public float distance;                  //distance to stay away from player

    


    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
		if(following.GetComponent<Rigidbody2D>().transform.position.y >                                 //if following is higher, move up
            ((GetComponent<Rigidbody2D>().transform.position.y) + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.y <                                //if following is lower move down
            ((GetComponent<Rigidbody2D>().transform.position.y) - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.x >                                //if following is right, move right
            ((GetComponent<Rigidbody2D>().transform.position.x) + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.x <                                //if following is left, move left
            ((GetComponent<Rigidbody2D>().transform.position.x) - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (health <= 0)
        {
            Die();
        }
        
    }

    public void Die() { }
}
