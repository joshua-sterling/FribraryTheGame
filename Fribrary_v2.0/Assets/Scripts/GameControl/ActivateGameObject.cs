using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class is used to activate game objects - 
 * the class can be assoicated with a game object in the editor
 * the function(s) in the class can then be called by that object */
public class ActivateGameObject : MonoBehaviour {

    public GameObject thingToActivate;              //the thing to activate is assigned in the editor

    /*This function will activate the game object that is assigned 
     * in the editor */
    public void activate()
    {
        thingToActivate.SetActive(true);            
    }
}
