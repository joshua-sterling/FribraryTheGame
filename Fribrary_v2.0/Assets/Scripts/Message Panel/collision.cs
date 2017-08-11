using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


/*This class handles the collision when the player collides with an NPC
 * In the editor this class should be assigned to an NPC
 * The specific public variables can be defiend in the editor for each NPC*/
public class collision : MonoBehaviour {

    private ModalPanel modalPanel;                                          //modal panel that will be used to display messages

    private UnityAction myYesAction, myNoAction, myOkayAction;            //set up the actions - yes, no and okay will be used

    public GameObject salsaRecipe;                                          //assign a gameobject in the editor
    
    /*Initializes the panel*/
    private void Awake()
    {
        modalPanel = ModalPanel.Instance();                              //set modal panel to a new instance

        myYesAction = new UnityAction(YesFunction);                 //assign the action for Yes
        myNoAction = new UnityAction(NoFunction);                   //assign the action for No
        myOkayAction = new UnityAction(OkayFunction);               //assign the action for Okay
    }

    /*displaying the modal panel will be initiated by the collision of game objects*/
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")                       //only show the panel if it is the player that collided with teh NPC
        {            
            if (GameController.controller.questActive)                  //if player is already on quest, don't offer it again
            {
                if (!GameController.controller.hasQuestItem)                                                               //see if player does not have quest item
                { modalPanel.Choice("We can't waste any more time - go get that salsa recipe!", myOkayAction); }            //if not, always show this message
                else
                {
                    switch (GameController.controller.npcMessageCount)                                                      //if player does have quest option, rotate through these 3 messages based on the message count
                    {
                        case 0:
                            modalPanel.Choice("You got the recipe!  You should hold onto it for a while.  It could come in handy later.", myOkayAction);
                            GameController.controller.npcMessageCount++;
                            break;
                        case 1:
                            modalPanel.Choice("Yeah that's really all the content we have right now.  Try again later.", myOkayAction);
                            GameController.controller.npcMessageCount++;
                            break;
                        case 2:
                            modalPanel.Choice("Seriously, that's all there is to do right now.", myOkayAction);
                            GameController.controller.npcMessageCount = 0;
                            break;
                    }

                }
            }
            else
            {                
                { modalPanel.Choice("These are dark times for Fribrary - kitchen bots are going wild.  Will you get me the salsa recipe?",      //player does not have the quest - offer it
                    myYesAction, myNoAction); }             
            }
        }
    }

    //set up some test functions - what will happen when the button gets pressed
    void YesFunction()
    {
        GameController.controller.questActive = true;                               //player accepted the quest
        activteQuestItem();                                                         //call function to activate quest item
    }

    void NoFunction()
    {
       //do nothing - closing the window is handled by modal panel class
    }

    void OkayFunction()
    {
        //do nothing - closing the window is handled by modal panel class
    }

    /*This function activtes the quest item and tells the game controller that it needs to be displayed*/
    public void activteQuestItem()
    {
        salsaRecipe.SetActive(true);                                                //activate teh quest item on the level
        GameController.controller.salsaRecipe = true;                               //tell game controller it needs to be displayed
    }


}
