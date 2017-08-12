using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitApplication : MonoBehaviour {

/*This function will exit the application
 * it can be called from any game object it is assigned to
 * in the editor */
public void exitApplication()
    {
        Application.Quit();                                         //this does not function in the editor - only in the .exe
    }
}
