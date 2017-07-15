using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EntityHealth : MonoBehaviour {

    public float currentHealth;
    public float maxHealth;
    public float damageTaken;           //for testing
    public bool dead = false;
    

    public Slider healthbar;

    private ModalPanel modalPanel;

    private UnityAction myYesAction, myNoAction, myOkayAction;            //set up the actions

    private void Awake()
    {
        modalPanel = ModalPanel.Instance();

        myOkayAction = new UnityAction(OkayFunction);                 //these actions get passed to the button call 
    }

    // Use this for initialization
    void Start () {
        if (gameObject.tag == "Player")
        { currentHealth = GameController.controller.playerCurrentHealth;
            maxHealth = GameController.controller.playerMaxHealth;

        }
        else
        {
            currentHealth = maxHealth;
        }

        healthbar.value = calculateHealth();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    float calculateHealth()
    {
        return currentHealth / maxHealth;
    }
  
    public void TakeDamage()
    {
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
