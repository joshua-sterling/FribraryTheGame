using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*this script can be called to load a scene on demand*/
public class LoadSceneOnClick : MonoBehaviour {

    //This function will load a scene supplied in the editor
    public void LoadByIndex(int scneneIndex)
    {
        SceneManager.LoadScene(scneneIndex);
    }
}
