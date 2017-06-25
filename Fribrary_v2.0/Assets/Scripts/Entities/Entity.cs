using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

    //There will never be an instance of entity - other classes wiill inherit
    public float speed;

    public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

    }

    public void damageEntity(int amount)
    {
        health -= amount;
    }
}
