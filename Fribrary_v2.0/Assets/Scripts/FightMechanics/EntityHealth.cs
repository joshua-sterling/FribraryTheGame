using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


/*The EntityHealth class is used in the fight scene to control
 * what happens to an entity when they take damage 
 * This class is assigned to Entity game objects in the editor*/
public class EntityHealth : MonoBehaviour {

    public float currentHealth;                                                 //entity current health
    public float maxHealth;                                                     //entity max health
    public float damageTaken;                                                   //how much damage should the entity take                                                                                 
    public bool dead = false;                                                   //is the entity dead    

    public Slider healthbar;                                                    //assign a slider to control for health
    private ModalPanel modalPanel;                                              //assign an instance of modalpanel to display messages
        
    private UnityAction myOkayAction;                                           //set up the action to send to modal panel

    private void Awake()
    {
        modalPanel = ModalPanel.Instance();                                     //gets an instance of the modal panel
        myOkayAction = new UnityAction(OkayFunction);                           //this action is passed to the modal panel
    }

    // Use this for initialization 
    void Start () {
        if (gameObject.tag == "Player")                                         //on start, get the health settings for the player from the gamecontroller
        { currentHealth = GameController.controller.playerCurrentHealth;
            maxHealth = GameController.controller.playerMaxHealth;

        }
        else
        {
            currentHealth = maxHealth;                                          //for non-player entities, get health from the object this script is attached to
        }

        healthbar.value = calculateHealth();                                    //calculate the health to display on the slider
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    float calculateHealth()
    {
        return currentHealth / maxHealth;                                       //for the slider bar, health needs to be a %, so divide current by max
    }
  
    /*This function is called during events that cause damage
     * to the entity this script is assigned to */
    public void TakeDamage()                                                    //entity is damaged, reduce health
    {
        if(gameObject.tag == "Player")                                          //if this is the player
        { GameController.controller.playerCurrentHealth -= damageTaken; }       //update the health in the game controller
        
        currentHealth -= damageTaken;                                           //for all entity types, update the current health displayed
        if(currentHealth < 0)
        {
            Die();                                                              //health is 0, entity has died
        }

        healthbar.value = calculateHealth();                                    //update the health bar slider
    }

    /*This function handles when the entity is killed*/
    public void Die()
    {
        currentHealth = 0;                                                              //damage may have taken health negative, set it to 0
        if (gameObject.tag == "Player")                                                 //if this entity is the player, call the modal panel with a message
        {
            modalPanel.Choice("You have died!", myOkayAction);                          //call modal panel to display a message
            dead = true;                                                                //set dead to true
            
        }
        else if(gameObject.tag == "Enemy")                                              //if the entity is tagged as an enemy, call the modal with a different message
        {
            modalPanel.Choice("The enemy has been destroyed!", myOkayAction);
            dead = true;
            
        }
    }

    //This function is called when the okay button is pressed in the modal panel
    void OkayFunction()
    {       
        SceneManager.LoadScene(1);                                              //change to scene 1, which is the main level

    }

}
