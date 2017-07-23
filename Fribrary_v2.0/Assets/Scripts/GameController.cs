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
    public bool hasQuestItem = false;
    public bool messagePanelActive = false;

    public Slider healthbar;

    public GameObject[] collectables;



    //creates an inventory instance for the player
    public List<Item> inventory = new List<Item>();
    //public List<ItemTemplate> inventoryTemplate = new List<ItemTemplate>();

    public int robotsSpawned = 0;

    public bool donut = false,
        key = false, salsaRecipe = false;


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
        data.recipe = salsaRecipe;
        data.hasQuestItem = hasQuestItem;

        /*inventory*/
        data.slot01 = controller.inventory[0].itemID;
        data.slot02 = controller.inventory[1].itemID;
        data.slot03 = controller.inventory[2].itemID;
        data.slot04 = controller.inventory[3].itemID;
        data.slot05 = controller.inventory[4].itemID;
        data.slot06 = controller.inventory[5].itemID;
        data.slot07 = controller.inventory[6].itemID;
        data.slot08 = controller.inventory[7].itemID;
        data.slot09 = controller.inventory[8].itemID;

       

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
            salsaRecipe = data.recipe;
            playerPlaceHolder.calculateHealth();
            hasQuestItem = data.hasQuestItem;     
            Debug.Log("Data Loaded!");

            //find all potential collectables
            collectables = GameObject.FindGameObjectsWithTag("Collectable");
            
            //bool slotFound = false;             //see if there is room in inventory
                   
            
            for(int i = 0; i<collectables.Length;i++)
            if(data.slot01 == collectables[i].gameObject.GetComponent<Item>().itemID)
                {
                    controller.inventory[0] = collectables[i].gameObject.GetComponent<Item>();
                }

            for (int i = 0; i < collectables.Length; i++)
                if (data.slot02 == collectables[i].gameObject.GetComponent<Item>().itemID)
                {
                    controller.inventory[1] = collectables[i].gameObject.GetComponent<Item>();
                }

            for (int i = 0; i < collectables.Length; i++)
                if (data.slot03 == collectables[i].gameObject.GetComponent<Item>().itemID)
                {
                    controller.inventory[2] = collectables[i].gameObject.GetComponent<Item>();
                }

            file.Close();
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
    public bool questActive, key, donut, recipe, hasQuestItem;
    public int slot01;
    public int slot02;
    public int slot03;
    public int slot04;
    public int slot05;
    public int slot06;
    public int slot07;
    public int slot08;
    public int slot09;
    public int slot10;


}