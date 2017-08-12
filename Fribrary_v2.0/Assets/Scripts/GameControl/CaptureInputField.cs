using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class CaptureInputField : MonoBehaviour {

    private ModalPanel modalPanel;                                          //modal panel that will be used to display messages
    private UnityAction myOkayAction;                                 //set up the actions - yes, no and okay will be used

    public InputField usernameInput;                                    //identifies the input field where name will be entered
    Regex alphaRegex = new Regex("[a-zA-Z]");                           //regular expression that identifies characters that are allowed


    public void Awake()
    {
        modalPanel = ModalPanel.Instance();                         //gets an instance of the modal panel
        myOkayAction = new UnityAction(OkayFunction);               //assign the action for Okay
    }

    public void validateUserName()
    {
        MatchCollection result = alphaRegex.Matches(usernameInput.text);

        if(result.Count == usernameInput.text.Length)
        {            
            GameController.controller.playerName = usernameInput.text;              //store the player name entered
            SceneManager.LoadScene(1);                                              //load the Main Level scene
        }
        else
        {
            modalPanel.Choice("Player name can only contain letters!", myOkayAction);            
        }
        
    }

    void OkayFunction()
    {
        //do nothing - closing the window is handled by modal panel class
    }
}
