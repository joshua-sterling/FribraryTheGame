using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingMob : Entity {

    public Entity following;
    public float distance;

    


    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if(following.GetComponent<Rigidbody2D>().transform.position.y > ((GetComponent<Rigidbody2D>().transform.position.y) + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.up * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.y < ((GetComponent<Rigidbody2D>().transform.position.y) - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.down * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.x > ((GetComponent<Rigidbody2D>().transform.position.x) + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.x < ((GetComponent<Rigidbody2D>().transform.position.x) - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * Time.deltaTime;
        }
        if (health <= 0)
        {
            Die();
        }
        
    }

    public void Die() { }
}
