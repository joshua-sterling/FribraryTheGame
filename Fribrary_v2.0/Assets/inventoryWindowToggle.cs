using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryWindowToggle : MonoBehaviour {

    public GameObject inventoryWindow;

    public void toggle()
    {
        if (inventoryWindow.activeInHierarchy)
        { inventoryWindow.SetActive(false); }
        else
        { inventoryWindow.SetActive(true); }
    }
}
