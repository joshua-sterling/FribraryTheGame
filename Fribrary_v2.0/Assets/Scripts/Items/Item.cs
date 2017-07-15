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

    private Item() { }

    public void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public Item(int id, string name, Texture2D icon, string desc)       //constructor
    {
        itemID = id;
        itemName = name;
        itemIcon = icon;
        itemDescription = desc;
    }

    /*TESTING
    public void Copy()
    {
        Item copy = new Item();
        copy.itemID = this.itemID;
        copy.itemName = this.itemName;
        copy.itemIcon = this.itemIcon;
        copy.itemDescription = this.itemDescription;
        copy.itemSprite = this.itemSprite;
        copy.itemObject = this.itemObject;
    }*/

}