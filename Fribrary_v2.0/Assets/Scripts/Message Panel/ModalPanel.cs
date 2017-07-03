using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {

    public Text question;
    public Image iconImage;
    public Button yesButton, noButton, okayButton;
    public GameObject modalPanelObject;

    private static ModalPanel modalPanel;                       //keep a static reference to this modal panel

    /*This function will return a static instance of the modal panel*/
    public static ModalPanel Instance()
    {
        if (!modalPanel)    //see if the modalPanel instance exists yet
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;                    //if not find it and cast it as a ModalPanel
            if (!modalPanel)
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in this scene");
        }
        return modalPanel;
    }

    /*Yes No Cancel function takes a String, yes event, no event, cancel event
     * the events contain what happens when those buttons clicked
     */
     public void Choice(string question, UnityAction yesEvent, UnityAction noEvent, UnityAction okayEvent)
    {
        modalPanelObject.SetActive(true);                    //open the modal panel

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
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        okayButton.gameObject.SetActive(true);

    }

    public void Choice(string question, Sprite iconImage, UnityAction yesEvent, UnityAction noEvent, UnityAction okayEvent)
    {
        modalPanelObject.SetActive(true);                    //open the modal panel

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

        this.iconImage.gameObject.SetActive(true);        //no background image yet
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        okayButton.gameObject.SetActive(true);

    }

    public void Choice(string question, UnityAction yesEvent, UnityAction noEvent)
    {
        modalPanelObject.SetActive(true);                    //open the modal panel

        yesButton.onClick.RemoveAllListeners();             //if this button is listening, cancel it
        yesButton.onClick.AddListener(yesEvent);            //add listener for the Yes event that is passed in
        yesButton.onClick.AddListener(closePanel);          //add listener for the close panel

        noButton.onClick.RemoveAllListeners();             //if this button is listening, cancel it
        noButton.onClick.AddListener(noEvent);            //add listener for the No event that is passed in
        noButton.onClick.AddListener(closePanel);          //add listener for the close panel
               
        this.question.text = question;                          //set the text to be displayed

        this.iconImage.gameObject.SetActive(false);        //no background image yet
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        okayButton.gameObject.SetActive(false);

    }


    void closePanel()
    {
        modalPanelObject.SetActive(false);          //close the modal panel window
    }

}
