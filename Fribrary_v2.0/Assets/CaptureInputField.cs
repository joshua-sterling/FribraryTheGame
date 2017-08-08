using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CaptureInputField : MonoBehaviour {

    public InputField usernameInput;                                    //identifies the input field where name will be entered
    Regex alphaRegex = new Regex("[a-zA-Z]");                           //regular expression that identifies characters that are allowed

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
            EditorUtility.DisplayDialog("Player Name Error!", "Player name can only contain letters!", "ok");
        }
        
    }

}
