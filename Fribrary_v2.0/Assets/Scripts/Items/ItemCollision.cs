using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour {

    private bool display = false;
    private GameObject currentCollision;
    private Item currentItem;

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        Debug.Log("Collision detected");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Collectable")
        {
            display = true;
            currentCollision = other.gameObject;
            currentItem = other.gameObject.GetComponent<Item>();
            Debug.Log("Colliding with collectable");            
        }

    }

    private void OnGUI()
    {
        if (display)
        {
            bool slotFound = false;
            int invCounter = 0;
            while(!slotFound && invCounter < gameObject.GetComponent<Player>().inventory.Count)
            {              
                if (gameObject.GetComponent<Player>().inventory[invCounter].itemID == 0)
                {
                    gameObject.GetComponent<Player>().inventory[invCounter] = currentCollision.gameObject.GetComponent<Item>();
                    gameObject.GetComponent<Player>().inventory[invCounter].itemObject = currentCollision;
                    slotFound = true;
                    if (currentCollision.tag == "Collectable")
                    {
                        Destroy(currentCollision);
                        Debug.Log("object destroyed");

                    }
                }
                else { invCounter++; }
            
            }
            if(!slotFound)
            { Debug.Log("Inventory is full!"); }
            
            display = false;
        }
    }

    
}
