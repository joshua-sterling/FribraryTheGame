using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGUI : MonoBehaviour {

    private Rect inventoryWindowRect = new Rect(800, 100, 210, 280);
    private bool showInventoryWindow = false;

    public Sprite keyIcon, emptyIcon;

    public Texture2D keyTexture, emptyTexture;

    


    private void Start()
    {
      
}

    private void Update()
    {

    }
    
    //set up the inventory window
    private void OnGUI()
    {
        showInventoryWindow = GUI.Toggle(new Rect(800, 50, 100, 50), showInventoryWindow, "Inventory");

        if(showInventoryWindow)
        {
            inventoryWindowRect = GUI.Window(0, inventoryWindowRect, InventoryWindow, "Inventory");
        }
    }

    void InventoryWindow(int windowID)
    {

          
        //button layout, referencing an item spot in the inventory      

        GUILayout.BeginArea(new Rect(5, 50, 320, 320));

        GUILayout.BeginHorizontal();
        GUILayout.Button(gameObject.GetComponent<Player>().inventory[0].itemIcon, GUILayout.Height(64), GUILayout.Width(64));
        GUILayout.Button(gameObject.GetComponent<Player>().inventory[1].itemIcon, GUILayout.Height(64), GUILayout.Width(64));
        GUILayout.Button(gameObject.GetComponent<Player>().inventory[2].itemIcon, GUILayout.Height(64), GUILayout.Width(64));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button(gameObject.GetComponent<Player>().inventory[3].itemIcon, GUILayout.Height(64), GUILayout.Width(64));
        GUILayout.Button(gameObject.GetComponent<Player>().inventory[4].itemIcon, GUILayout.Height(64), GUILayout.Width(64));
        GUILayout.Button(gameObject.GetComponent<Player>().inventory[5].itemIcon, GUILayout.Height(64), GUILayout.Width(64));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button(gameObject.GetComponent<Player>().inventory[6].itemIcon, GUILayout.Height(64), GUILayout.Width(64));
        GUILayout.Button(gameObject.GetComponent<Player>().inventory[7].itemIcon, GUILayout.Height(64), GUILayout.Width(64));
        GUILayout.Button(gameObject.GetComponent<Player>().inventory[8].itemIcon, GUILayout.Height(64), GUILayout.Width(64));
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }


}
