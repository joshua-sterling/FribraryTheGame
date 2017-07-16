using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class collision : MonoBehaviour {

    private ModalPanel modalPanel;

    private UnityAction myYesAction, myNoAction, myOkayAction;            //set up the actions

    public GameObject salsaRecipe;
    Vector2 recipeSpawn = new Vector2(2, 6);

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
                modalPanel.Choice("We can't waste any more time - go get that salsa recipe!", myOkayAction);
            }
            else
            {
                modalPanel.Choice("These are dark times for Fribrary - kitchen bots are going wild.  Will you get me the salsa recipe?", myYesAction, myNoAction);
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
        Instantiate(salsaRecipe, recipeSpawn, Quaternion.identity);
    }


}
