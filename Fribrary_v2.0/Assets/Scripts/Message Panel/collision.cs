using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class collision : MonoBehaviour {

    private ModalPanel modalPanel;

    private UnityAction myYesAction, myNoAction, myCancelAction;            //set up the actions

    private void Awake()
    {
        modalPanel = ModalPanel.Instance();

        myYesAction = new UnityAction(TestYesFunction);                 //these actions get passed to the button call 
        myNoAction = new UnityAction(TestNoFunction);
        myCancelAction = new UnityAction(TestCancelFunction);


    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision WITH NPC");
        modalPanel.Choice("This is a test message with 2 buttons to choose from", myYesAction, myNoAction);
    }

    //set up some test functions - what will happen when the button gets pressed
    void TestYesFunction()
    {
        Debug.Log("The YES button got pressed after collision");
    }

    void TestNoFunction()
    {
        Debug.Log("The NO button got pressed after collision");
    }

    void TestCancelFunction()
    {
        Debug.Log("The CANCEL button got pressed after collision");
    }

}
