using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollision : MonoBehaviour {

    private bool display = false;                           //show the item in inventory
    private GameObject currentCollision;                    //what is the most recent object collided
    private Item currentItem;                               //what is the most recent item collided

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        Debug.Log("Collision detected");                        //log to console
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Collectable")                          //only take action if the tag is Collectable
        {
            display = true;                                             //show it in inventory
            currentCollision = other.gameObject;                        //set the current collision object
            currentItem = other.gameObject.GetComponent<Item>();        //set the current collision item
            Debug.Log("Colliding with collectable");                   //log to console
            if(other.gameObject.GetComponent<Item>().itemID == 2)       //don't display donut anymore
            {
                GameController.controller.donut = false;
            }
            else if (other.gameObject.GetComponent<Item>().itemID == 1)       //don't display donut anymore
            {
                GameController.controller.key = false;
            }
            else if (other.gameObject.GetComponent<Item>().itemID == 3)
            {
                GameController.controller.salsaRecipe = false;
                GameController.controller.hasQuestItem = true;
            }
            //**************************************TESTING
            //GameController.controller.inventory[5] = other.gameObject.GetComponent<Item>().Clone();
        }
        else if(other.gameObject.tag == "Enemy")
        {
            GameController.controller.playerLocation = gameObject.GetComponent<Rigidbody2D>().position;
            SceneManager.LoadScene(2);
            Debug.Log("This should load the fight scene..");
        }

    }

    private void OnGUI()
    {
        if (display)                            //is there something to show in teh inventory
        {
            bool slotFound = false;             //see if there is room in inventory
            int invCounter = 0;                 //iterator
            //while(!slotFound && invCounter < gameObject.GetComponent<Player>().inventory.Count)
            while (!slotFound && invCounter < GameController.controller.inventory.Count)
            {
                //if (gameObject.GetComponent<Player>().inventory[invCounter].itemID == 0)    //look for item ID 0, which is empty spot
                if (GameController.controller.inventory[invCounter].itemID == 0)
                {
                    GameController.controller.inventory[invCounter] =                   //put object in inventory
                        currentCollision.gameObject.GetComponent<Item>();
                    GameController.controller.inventory.Add(currentCollision.gameObject.GetComponent<Item>());      //use Add() instead
                   
                    GameController.controller.inventory[invCounter].itemObject =        //put item in inventory
                        currentCollision;
                    slotFound = true;                                                       //spot was found, stop looking
                    if (currentCollision.tag == "Collectable")                      //double check it is collectable
                    {
                        //Destroy(currentCollision);                                  //destroy the object
                        currentCollision.gameObject.transform.position= new Vector2 (-15,0);              //instead of destroying, throw off screen
                        Debug.Log("object destroyed");                      //log to console

                    }
                }
                else { invCounter++; }                              //not an empty spot, look at the next one
            
            }
            if(!slotFound)
            { Debug.Log("Inventory is full!"); }                //no slot found means inventory is full
            
            display = false;                                    //reset the control
        }
    }

    
}
