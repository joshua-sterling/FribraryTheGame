using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingMob : Entity {

    public GameObject attacking1;
    public Entity attacking;
    public int distance;

    private bool canAttack;

	// Use this for initialization
	void Start () {
        canAttack = true;
        if(attacking1==null)
        {
            attacking1 = GameObject.FindGameObjectWithTag("Player");
            attacking = attacking1.GetComponent<Entity>();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (attacking.GetComponent<Rigidbody2D>().transform.position.y > ((GetComponent<Rigidbody2D>().transform.position.y) + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.up * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.y < ((GetComponent<Rigidbody2D>().transform.position.y) - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.down * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.x > ((GetComponent<Rigidbody2D>().transform.position.x) + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.x < ((GetComponent<Rigidbody2D>().transform.position.x) - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * Time.deltaTime;
        }
        if(Vector2.Distance(GetComponent<Rigidbody2D>().transform.position, attacking.transform.position) <= distance)
        {
            attackEntity();
            StartCoroutine(waitForAttack());
        }



        if (health <= 0)
        {
            Die();
        }
    }

    public void Die() { }

    public void attackEntity()
    {
        int damage = Random.Range(1, 20);
        attacking.damageEntity(damage);
    }

    IEnumerator waitForAttack()                     //can only attack every 2 seconds
    {
        canAttack = false;
        yield return new WaitForSeconds(2);         //in this function wait for 2 seconds
        canAttack = true;

    }
}
