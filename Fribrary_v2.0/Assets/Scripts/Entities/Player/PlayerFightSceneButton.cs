using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is used to control actions from the players attack button in the fight scene
public class PlayerFightSceneButton : MonoBehaviour {

    //instance of the animator for this object
    private Animator animator;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();                                //set the animator to the component assigned to this game object
    }

   
    //This function calls the player attack animation
    public void playerShoot()
    {
        animator.SetTrigger("PlayerTrigger");
    }
}
