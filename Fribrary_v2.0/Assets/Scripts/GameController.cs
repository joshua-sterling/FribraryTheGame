using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*This class will persist from scene to scene and will hold all of the data that is needed between scenes*/
public class GameController : MonoBehaviour {

    public static GameController controller;

    public float playerCurrentHealth;
    public float playerMaxHealth;
    public float playerExperience;
    public Vector2 playerLocation;

    //creates an inventory instance for the player
    public List<Item> inventory = new List<Item>();


    public bool donut = false,
        key = false;


    // Use this for initialization
    void Awake () {                                 //Awake happens before Start happens
        if (controller == null)                     //if there is no controller
        {
            DontDestroyOnLoad(gameObject);          //set this as the controller
            controller = this;
        }
        else if(controller != this)                 //if there is a controller already and this is not it, destroy this
        {
            Destroy(gameObject);
        }

	}
	
}
