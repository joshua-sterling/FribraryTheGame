using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*This class controls what happens when the player collides 
 * with different times of game items */
public class ItemCollision : MonoBehaviour {

    private bool display = false;                           //show the item in inventory
    private GameObject currentCollision;                    //what is the most recent object collided
    private Item currentItem;                               //what is the most recent item collided

    private void OnCollisionEnter2D(Collision2D other)
    {    
        if (other.gameObject.tag == "Collectable")                              //only take action if the tag is Collectable
        {
            display = true;                                                     //show it in inventory
            currentCollision = other.gameObject;                                //set the current collision object
            currentItem = other.gameObject.GetComponent<Item>();                //set the current collision item
            
            if(other.gameObject.GetComponent<Item>().itemID == 2)               //did player collide with item ID 2
            {
                GameController.controller.donut = false;                        //itemID 2 collected, don't show it anymore 
            }
            else if (other.gameObject.GetComponent<Item>().itemID == 1)         //did player collide with item ID 1
            {
                GameController.controller.key = false;                          //itemID 3 collected, don't show it anymore 
            }
            else if (other.gameObject.GetComponent<Item>().itemID == 3)          //did player collide with item ID 3
            {
                GameController.controller.salsaRecipe = false;                   //recipe collected, don't show it anymore   
                GameController.controller.hasQuestItem = true;                   //player now has quest item, set this to true
            }
            
        }
        else if(other.gameObject.tag == "Enemy")                                //did the player collide with an enemy
        {
            GameController.controller.playerLocation = gameObject.GetComponent<Rigidbody2D>().position;         //remember where the player is, scene is about to change
            SceneManager.LoadScene(2);                                                                          //change to fight scene            
        }

    }

    /*OnGUI is called for rendering and handling GUI events*/
    private void OnGUI()
    {
        if (display)                                                          //is there something to show in teh inventory
        {
            bool slotFound = false;                                           //see if there is room in inventory
            int invCounter = 0;                                               //iterator
            
            while (!slotFound && invCounter < GameController.controller.inventory.Count)        //loop through inventory slots looking for an empty slot
            {                
                if (GameController.controller.inventory[invCounter].itemID == 0)                //itemID 0 represents an empty slot
                {
                    GameController.controller.inventory[invCounter] =                            //put item in inventory
                        currentCollision.gameObject.GetComponent<Item>();                                      
                   
                    slotFound = true;                                                       //spot was found, stop looking
                    if (currentCollision.tag == "Collectable")                              //double check it is collectable
                    {                        
                        currentCollision.gameObject.transform.position= new Vector2 (-15,0);              //instead of destroying, throw object off screen                        
                    }
                }
                else { invCounter++; }                                       //not an empty spot, look at the next one
            
            }
            if(!slotFound)
            { print("Inventory is full!"); }                //no slot found means inventory is full
            
            display = false;                                    //reset the control
        }
    }

    
}
