using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                       //serializable allows editor to see them
public class Item : MonoBehaviour
{

    public int itemID;                      //identifier for the item
    public string itemName;                 //item name
    public Texture2D itemIcon;              //Texture for buttons
    public string itemDescription;          //descritiption to be displayed
    public Sprite itemSprite;               //Sprite to be displayed
    public GameObject itemObject;           //game object to reference

    
    public void Start()
    {
        DontDestroyOnLoad(transform.gameObject);                        //ensures these objects don't get destroyed between scenes
    }

    public Item(int id, string name, Texture2D icon, string desc)       //constructor
    {
        itemID = id;                          //set ID
        itemName = name;                      //set name
        itemIcon = icon;                     //set icon
        itemDescription = desc;                //set description
    }

  

}