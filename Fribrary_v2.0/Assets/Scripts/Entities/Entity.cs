using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

    //There will never be an instance of entity - other classes wiill inherit
    public float speed;                                     //how fast this until will move

    public int health;                                      //health of the unit

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

    }

    //this function will have the entity take damage 
    public void damageEntity(int amount)
    {
        health -= amount;                                   //reduce health by damage amount
    }
}
