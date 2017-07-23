using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.UI;

/*This class will persist from scene to scene and will hold all of the data that is needed between scenes*/
public class GameController : MonoBehaviour {

    public static GameController controller;

    public float playerCurrentHealth;
    public float playerMaxHealth;
    public float playerExperience;
    public Vector2 playerLocation;

    public Player playerPlaceHolder;
    public bool questActive = false;
    public bool messagePanelActive = false;

    public Slider healthbar;

 
    

    //creates an inventory instance for the player
    public List<Item> inventory = new List<Item>();
    //public List<ItemTemplate> inventoryTemplate = new List<ItemTemplate>();

    public int robotsSpawned = 0;

    public bool donut = false,
        key = false;


    // Use this for initialization
    void Awake () {                                 //Awake happens before Start happens
        if (controller == null)                     //if there is no controller
        {
            DontDestroyOnLoad(gameObject);          //set this as the controller
            controller = this;
        }
        else if(controller != this)                 //if there is a controller already and this is not it, destroy this
        {
            Destroy(gameObject);
        }

	}

    /* 
     * Saves game data out to a file in binary format
     */
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();                                             //will save as binary
        FileStream file = File.Create(Application.persistentDataPath 
            + "/playerInfo.dat");                                                               //persistent data path for Unity data

        PlayerData data = new PlayerData();                                                     //create an instance of serializeable player data
        data.playerCurrentHealth = GameController.controller.playerCurrentHealth;                                         //capture player data
        data.playerExperience = playerExperience;
        data.questActive = questActive;
        data.key = key;
        data.donut = donut;
        data.inventory.AddRange(inventory);
       
        bf.Serialize(file, data);                                                               //write the instance of serializeable data to file 
        Debug.Log("Data Saved!");
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))                    //see if the game file even exists
        {
            BinaryFormatter bf = new BinaryFormatter();                                         //create an instance of the binary formatter
            FileStream file = File.Open(Application.persistentDataPath +
                "/playerInfo.dat", FileMode.Open);                                             //open the saved file
            PlayerData data = (PlayerData)bf.Deserialize(file);                                 //cast the deserialized file back to a PlayerData object
            
            GameController.controller.playerCurrentHealth = data.playerCurrentHealth;                                     //set game data equal to saved data
            playerExperience = data.playerExperience;
            questActive = data.questActive;
            key = data.key;
            donut = data.donut;
            playerPlaceHolder.calculateHealth();
            inventory.AddRange(data.inventory);
            Debug.Log("Data Loaded!");
        }
    }

    float calculateHealth()
    {
        return playerCurrentHealth / playerMaxHealth;
    }

}

/*
 * class specifically for saving data
 * 
 */
 [Serializable()]
 class PlayerData
{
    public float playerCurrentHealth;
    public float playerExperience;
    public bool questActive, key, donut;
    public List<Item> inventory = new List<Item>();


}