using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*This class is used to create "Buttons" that represent inventory items
 * by using buttons, events are easily called by OnClick, OnHover, etc */
public class inventoryButton : MonoBehaviour {

    public int buttonID;              //ID for tracking the button, to be assigned in the editor
    public Text toolTipBox;           //assign the tooltip textbox in the ditor where descriptions will display
   
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Image>().sprite = GameController.controller.inventory[buttonID].itemSprite;         //on start set the image for this button based on corresponding inventory item

    }
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnGUI()
    {
        //update the inventory in the GUI so that it changes as items are picked up
        gameObject.GetComponent<Image>().sprite = GameController.controller.inventory[buttonID].itemSprite;
       
    }
    
    /*This function will display the description of the inventory object associated with this button*/
    public void showDescription()
    {
        toolTipBox.text = GameController.controller.inventory[buttonID].itemDescription;                            //show item description in the tooltip box
    }

    /*This function will hide the tooltip text box*/
    public void hideDescription()
    {
        toolTipBox.text = null;
    }

   
}
