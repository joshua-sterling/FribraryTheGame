using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealth : MonoBehaviour {

    public float currentHealth;
    public float maxHealth;

    public Slider healthbar;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;

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
        currentHealth -= 10;
        if(currentHealth < 0)
        {
            Die();
        }

        healthbar.value = calculateHealth();
    }

    void Die()
    {
        currentHealth = 0;
        Debug.Log("You died");
    }


}
