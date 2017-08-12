using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class controls the display of the inventory window*/
public class inventoryWindowToggle : MonoBehaviour {

    public GameObject inventoryWindow;                                  //assign the inventory window game object in the editor

    //function that can be called to toggle the inventory window on and off
    public void toggle()
    {
        if (inventoryWindow.activeInHierarchy)                          //if window is showing, hide it
        { inventoryWindow.SetActive(false); }
        else
        { inventoryWindow.SetActive(true); }                            //else if not showing, show it
    }
}
