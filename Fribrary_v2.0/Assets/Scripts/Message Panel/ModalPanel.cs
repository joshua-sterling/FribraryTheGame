using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/*This class creates modal message panels that can be used to display
 * test, icons, and buttons*/
public class ModalPanel : MonoBehaviour {

    public Text question;                                       //text to display in the panel
    public Image iconImage;                                     //image to display in the panel
    public Button yesButton, noButton, okayButton;              //buttons to display in panel
    public GameObject modalPanelObject;                         //game ojbect to represent teh panel
    public Slider playerHealth;                                 //use to control when health bar is shown so it does not appear on top of message box   

    private static ModalPanel modalPanel;                       //keep a static reference to this modal panel

    /*This function will return a static instance of the modal panel*/
    public static ModalPanel Instance()
    {
        if (!modalPanel)    //see if the modalPanel instance exists yet
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;                    //if not find it and cast it as a ModalPanel
            
        }
        return modalPanel;
    }

    /*Choice function takes a String, yes event, no event, cancel event
     * the events contain what happens when those buttons clicked
     */
     public void Choice(string question, UnityAction yesEvent, UnityAction noEvent, UnityAction okayEvent)
    {
        modalPanelObject.SetActive(true);                    //open the modal panel
        GameController.controller.messagePanelActive = true;
        if (SceneManager.GetActiveScene().buildIndex == 1)      //see if the main level is loaded
        { playerHealth.gameObject.SetActive(false); }           //hide the player health slider as it will render on top of the panel

        yesButton.onClick.RemoveAllListeners();             //if this button is listening, cancel it
        yesButton.onClick.AddListener(yesEvent);            //add listener for the Yes event that is passed in
        yesButton.onClick.AddListener(closePanel);          //add listener for the close panel

        noButton.onClick.RemoveAllListeners();             //if this button is listening, cancel it
        noButton.onClick.AddListener(noEvent);            //add listener for the No event that is passed in
        noButton.onClick.AddListener(closePanel);          //add listener for the close panel

        okayButton.onClick.RemoveAllListeners();             //if this button is listening, cancel it
        okayButton.onClick.AddListener(okayEvent);            //add listener for the Cancel event that is passed in
        okayButton.onClick.AddListener(closePanel);          //add listener for the close panel

        this.question.text = question;                          //set the text to be displayed

        this.iconImage.gameObject.SetActive(false);        //no background image yet
        yesButton.gameObject.SetActive(true);               //uses all 3 button
        noButton.gameObject.SetActive(true);
        okayButton.gameObject.SetActive(true);

    }

    /*Overload Choice to be called with text, icon, and 3 buttons*/
    public void Choice(string question, Sprite iconImage, UnityAction yesEvent, UnityAction noEvent, UnityAction okayEvent)
    {
        modalPanelObject.SetActive(true);                    //open the modal panel
        GameController.controller.messagePanelActive = true;
        if (SceneManager.GetActiveScene().buildIndex == 1)          //see if the main level is loaded
        { playerHealth.gameObject.SetActive(false); }               //hide the player health slider as it will render on top of the panel

        yesButton.onClick.RemoveAllListeners();             //if this button is listening, cancel it
        yesButton.onClick.AddListener(yesEvent);            //add listener for the Yes event that is passed in
        yesButton.onClick.AddListener(closePanel);          //add listener for the close panel

        noButton.onClick.RemoveAllListeners();             //if this button is listening, cancel it
        noButton.onClick.AddListener(noEvent);            //add listener for the No event that is passed in
        noButton.onClick.AddListener(closePanel);          //add listener for the close panel

        okayButton.onClick.RemoveAllListeners();             //if this button is listening, cancel it
        okayButton.onClick.AddListener(okayEvent);            //add listener for the Cancel event that is passed in
        okayButton.onClick.AddListener(closePanel);          //add listener for the close panel

        this.question.text = question;                          //set the text to be displayed
        this.iconImage.sprite = iconImage;

        this.iconImage.gameObject.SetActive(true);        //has a background image
        yesButton.gameObject.SetActive(true);               //uses all 3 buttons
        noButton.gameObject.SetActive(true);
        okayButton.gameObject.SetActive(true);

    }

    /*Overload Choice to be called with text, and 2 buttons*/
    public void Choice(string question, UnityAction yesEvent, UnityAction noEvent)
    {
        modalPanelObject.SetActive(true);                    //open the modal panel
        GameController.controller.messagePanelActive = true;
        if (SceneManager.GetActiveScene().buildIndex == 1)          //see if the main level is loaded
        { playerHealth.gameObject.SetActive(false); }               //hide the player health slider as it will render on top of the panel

        yesButton.onClick.RemoveAllListeners();             //if this button is listening, cancel it
        yesButton.onClick.AddListener(yesEvent);            //add listener for the Yes event that is passed in
        yesButton.onClick.AddListener(closePanel);          //add listener for the close panel

        noButton.onClick.RemoveAllListeners();             //if this button is listening, cancel it
        noButton.onClick.AddListener(noEvent);            //add listener for the No event that is passed in
        noButton.onClick.AddListener(closePanel);          //add listener for the close panel
               
        this.question.text = question;                          //set the text to be displayed

        this.iconImage.gameObject.SetActive(false);        //no background image 
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        okayButton.gameObject.SetActive(false);             //does not use Okay button

    }

    /*Overload Choice to be called with text and 1 button*/
    public void Choice(string question, UnityAction okayEvent)
    {
        modalPanelObject.SetActive(true);                    //open the modal panel
        GameController.controller.messagePanelActive = true;
        if (SceneManager.GetActiveScene().buildIndex == 1)          //see if main level is loaded
        { playerHealth.gameObject.SetActive(false); }               //hide the player health slider as it will render on top of the panel

        okayButton.onClick.RemoveAllListeners();             //if this button is listening, cancel it
        okayButton.onClick.AddListener(okayEvent);            //add listener for the No event that is passed in
        okayButton.onClick.AddListener(closePanel);          //add listener for the close panel

        this.question.text = question;                          //set the text to be displayed

        this.iconImage.gameObject.SetActive(false);        //no background image 
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        okayButton.gameObject.SetActive(true);              //only uses Okay button

    }


    void closePanel()
    {
        modalPanelObject.SetActive(false);                           //close the modal panel window
        GameController.controller.messagePanelActive = false;       //tell the game controller the panel is no longer active
        if (SceneManager.GetActiveScene().buildIndex == 1)          //if the main level is loaded, unhide the player health slider
        { playerHealth.gameObject.SetActive(true); }
    }

}
