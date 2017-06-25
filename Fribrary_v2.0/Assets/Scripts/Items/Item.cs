using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour  {
    
    public int itemID;
    public string itemName;
    public Texture2D itemIcon;
    public string itemDescription;
    public Sprite itemSprite;
    public GameObject itemObject;
   

    public Item(int id, string name, Texture2D icon, string desc)
    {
        itemID = id;
        itemName = name;
        itemIcon = icon;
        itemDescription = desc;
    }


}
