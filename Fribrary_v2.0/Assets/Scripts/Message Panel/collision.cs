using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class collision : MonoBehaviour {

    private ModalPanel modalPanel;

    private UnityAction myYesAction, myNoAction, myOkayAction;            //set up the actions

    public GameObject salsaRecipe;
    

    private void Awake()
    {
        modalPanel = ModalPanel.Instance();

        myYesAction = new UnityAction(TestYesFunction);                 //these actions get passed to the button call 
        myNoAction = new UnityAction(TestNoFunction);
        myOkayAction = new UnityAction(TestOkayFunction);


    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision WITH NPC");
            if (GameController.controller.questActive)                  //if player is already on quest, don't offer it again
            {
                if (!GameController.controller.hasQuestItem)
                { modalPanel.Choice("We can't waste any more time - go get that salsa recipe!", myOkayAction); }
                else
                {
                    switch (GameController.controller.npcMessageCount)
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
                { modalPanel.Choice("These are dark times for Fribrary - kitchen bots are going wild.  Will you get me the salsa recipe?", myYesAction, myNoAction); }             
            }
        }
    }

    //set up some test functions - what will happen when the button gets pressed
    void TestYesFunction()
    {
        Debug.Log("The YES button got pressed after collision");
        GameController.controller.questActive = true;
        activteQuestItem();
      
    }

    void TestNoFunction()
    {
        Debug.Log("The NO button got pressed after collision");
    }

    void TestOkayFunction()
    {
        Debug.Log("The OKAY button got pressed after collision");
    }


    public void activteQuestItem()
    {
        salsaRecipe.SetActive(true);
    }


}
