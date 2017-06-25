using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    public int direction;

    //change the player graphic to face the correct direction
    public Sprite down;
    public Sprite up;
    public Sprite right;
    public Sprite left;

    bool walkLeft = false, walkRight = false, walkUp = false, walkDown = false, playerIdle = false;

    public SpriteRenderer spriteParent;

    private Animator animator;

   

    public List<Item> inventory = new List<Item>();


    //  public PlayerItemManager inventory;




    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        walkRight = Input.GetKey(KeyCode.D);
        walkDown = Input.GetKey(KeyCode.S);
        walkUp = Input.GetKey(KeyCode.W);
        walkLeft = Input.GetKey(KeyCode.A);

        if(!walkRight && !walkDown && !walkUp && !walkLeft)
        {
            playerIdle = true;
        }
        else
        {
            playerIdle = false;
        }
        
        animator.SetBool("WalkDown", walkDown);
        animator.SetBool("WalkRight", walkRight);
        animator.SetBool("WalkUp", walkUp);
        animator.SetBool("WalkLeft", walkLeft);
        animator.SetBool("PlayerIdle", playerIdle);

    
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
           
            GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
            direction = 1;     
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            
            GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
            direction = 0;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
            direction = 2;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
            direction = 3;
        }
        




        if (direction == 0)
        {
            spriteParent.sprite = down;
        }
        if (direction == 1)
        {
            spriteParent.sprite = up;
        }
        if (direction == 2)
        {
            spriteParent.sprite = left;
        }
        if (direction == 3)
        {
            spriteParent.sprite = right;
        }

        if (health <= 0)
        {
            Die();
        }

    }

    public void Die() { print("Well, crap."); }

    public void changeDirection()
    {

    }

   

}
