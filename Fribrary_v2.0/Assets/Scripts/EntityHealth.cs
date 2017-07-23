using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EntityHealth : MonoBehaviour {

    public float currentHealth;                                                 //entity current health
    public float maxHealth;                                                     //entity max health
    public float damageTaken;                                                   //how much damage should the entity take -
                                                                                //ultimately this will be determined by what damages them but for now is a public variable
    public bool dead = false;                                                   //is the entity dead
    

    public Slider healthbar;                                                    //assign a slider to control for health

    private ModalPanel modalPanel;                                              //assign an instance of modalpanel to display messages
        
    private UnityAction myYesAction, myNoAction, myOkayAction;                  //set up the actions to send to modal panel

    private void Awake()
    {
        modalPanel = ModalPanel.Instance();

        myOkayAction = new UnityAction(OkayFunction);                           //these actions get passed to the button call 
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

        healthbar.value = calculateHealth();                                    //calculate the health
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    float calculateHealth()
    {
        return currentHealth / maxHealth;                                       //for the slider bar, health needs to be a %, so divide current by max
    }
  
    public void TakeDamage()                                                    //entity is damaged, reduce health
    {
        if(gameObject.tag == "Player")                                          //if this is the player
        { GameController.controller.playerCurrentHealth -= damageTaken; }
        Debug.Log("Take damage called");
        currentHealth -= damageTaken;
        if(currentHealth < 0)
        {
            Die();
        }

        healthbar.value = calculateHealth();
    }

    public void Die()
    {
        currentHealth = 0;
        if (gameObject.tag == "Player")
        { Debug.Log("You died"); }
        else if(gameObject.tag == "Enemy")
        {
            modalPanel.Choice("The enemy has been destroyed!", myOkayAction);
            dead = true;
            Debug.Log("Enemy should have died...");
        }
    }

    //set up some test functions - what will happen when the button gets pressed
    void OkayFunction()
    {
        Debug.Log("The OKAY button got pressed after enemy destroyed");
        SceneManager.LoadScene(1);

    }

}
