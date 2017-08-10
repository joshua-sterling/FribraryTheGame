using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;

/*This class will persist from scene to scene and 
 * will hold all of the data that is needed between scenes
 * It will also manage game saves and loads */
public class GameController : MonoBehaviour {

    public static GameController controller;                                                //creates a singleton instance that will persist through each scene
    public string playerName = "";                                                          //holds player name 

    public float playerCurrentHealth;                                                       //players current health
    public float playerMaxHealth;                                                           //players maximum health
    public float playerExperience;                                                          //player experience points
    public Vector2 playerLocation;                                                          //used to keep track of players location when switching scenes

    public Player playerPlaceHolder;                                                        //a game object assigned in editor to represent the player object
    public bool questActive = false;                                                        //does the player have an active quest
    public bool hasQuestItem = false;                                                       //does the player currently have the quest item
    public bool messagePanelActive = false;                                                 //is the modal message panel active
    public int npcMessageCount = 0;                                                         //a count to remember how many messages the npc has displayed

    
    public GameObject[] collectables;                                                       //array of collectable game objects 
     
    public List<Item> inventory = new List<Item>();                                         //creates an inventory instance for the player
    
    public int robotsSpawned = 0;                                                           //keep track of how many robots have been spawned

    public bool donut = false,                                                              //used to determine if given collectable needs to be displayed
        key = false, salsaRecipe = false;                                                   //used when changing scenes


    // Use this for initialization
    void Awake () {                                                                          //Awake happens before Start happens
        if (controller == null)                                                              //if there is no controller
        {
            DontDestroyOnLoad(gameObject);                                                   //set this as the controller
            controller = this;
        }
        else if(controller != this)                                                         //if there is a controller already and this is not it, destroy this
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
        FileStream file = File.Create(Application.persistentDataPath                            //create a file to save player data
            + "/playerInfo.dat");                                                               //persistent data path for Unity data

        FileStream chk = File.Create(Application.persistentDataPath                             //create a checksum file
             + "/check.dat");

        PlayerData data = new PlayerData();                                                     //create an instance of serializeable player data that can be written to file

        /* Player data that needs to be saved to file
         * data in serializeable data object is set to equal the corresponding
         * data in the game controller singleton*/
        data.playerCurrentHealth = controller.playerCurrentHealth;                             
        data.playerExperience = controller.playerExperience;
        data.questActive = controller.questActive;
        data.key = controller.key;
        data.donut = controller.donut;
        data.recipe = controller.salsaRecipe;
        data.hasQuestItem = controller.hasQuestItem;
        data.playerName = controller.playerName;
        
        /*Also capture the ID of each item in player inventory*/
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
       
        file.Close();                                                                           //finished with player data file, close it

        string MD5checksum = GetFileChecksum(Application.persistentDataPath +                   //create a hash of the player file and save it to a string
            "/playerInfo.dat", new MD5CryptoServiceProvider());

        bf.Serialize(chk, MD5checksum);                                                         //use the binary formatter to write the checksum to a separate file 

        chk.Close();                                                                            //finished with the checksum file, close it      

    }

    /*This function will get a hash of the player data file and compare it
     * to the saved checksum from the last game save action and return bool */
    public bool validateFile()
    {
        BinaryFormatter bf = new BinaryFormatter();                                         //create an instance of the binary formatter
        FileStream file = File.Open(Application.persistentDataPath                              
             + "/check.dat", FileMode.Open);                                                //open the saved file containing the checksum

        string gameFileChecksum = GetFileChecksum(Application.persistentDataPath +          //get MD5 hash of the saved game file
            "/playerInfo.dat", new MD5CryptoServiceProvider());
      
        string savedChecksum = (string)bf.Deserialize(file);                                //deserialize the saved checksum and assign it to a string
           

        if (gameFileChecksum == savedChecksum) { return true; }                             //compare the saved checksum to that of the saved file - return true if they match
        else { return false; }                                                              //return false if they do not match 
                

    }


    /*This function will load a saved game file and validate the saved data*/
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))                    //see if the game file even exists
        {
            if (validateFile())                                                                       //first call the checksum validation - only proceed if it validates
                
            {
                BinaryFormatter bf = new BinaryFormatter();                                         //create an instance of the binary formatter
                FileStream file = File.Open(Application.persistentDataPath +
                    "/playerInfo.dat", FileMode.Open);                                             //open the saved file of player data


                PlayerData data = (PlayerData)bf.Deserialize(file);                                 //cast the deserialized file back to a PlayerData object

                controller.playerCurrentHealth = data.playerCurrentHealth;                              //set game data equal to saved data
                controller.playerExperience = data.playerExperience;
                controller.questActive = data.questActive;
                controller.key = data.key;
                controller.donut = data.donut;
                controller.salsaRecipe = data.recipe;
                playerPlaceHolder.calculateHealth();                                                  //set the health on the player object
                controller.playerName = data.playerName;
                controller.hasQuestItem = data.hasQuestItem;
                

                //find all potential collectables and store them in an array
                collectables = GameObject.FindGameObjectsWithTag("Collectable");                    /*call gameobject member function (a Unity built in function) to find all game objects
                                                                                                    *with game object tag */
                
                //Load teh inventory
                for (int i = 0; i < collectables.Length; i++)                                                       //slot 1 - see what item should be there
                    if (data.slot01 == collectables[i].gameObject.GetComponent<Item>().itemID)
                    {
                        controller.inventory[0] = collectables[i].gameObject.GetComponent<Item>();
                    }

                for (int i = 0; i < collectables.Length; i++)
                    if (data.slot02 == collectables[i].gameObject.GetComponent<Item>().itemID)                       //slot 2 - see what item should be there
                    {
                        controller.inventory[1] = collectables[i].gameObject.GetComponent<Item>();
                    }

                for (int i = 0; i < collectables.Length; i++)                                                       //slot 3 - see what item should be there
                    if (data.slot03 == collectables[i].gameObject.GetComponent<Item>().itemID)
                    {
                        controller.inventory[2] = collectables[i].gameObject.GetComponent<Item>();
                    }

                file.Close();
            }
            else { Debug.Log("File is corrupted!  Cannot load."); }                                                 //checksum validation failed - do not load - must start new game
        }
        else{ Debug.Log("No file found!"); }                                                                        //no file available to load - must start new game
       
    }

    /*This function will calculate health to be assigned to the player object*/
    float calculateHealth()
    {
        return playerCurrentHealth / playerMaxHealth;
    }


    /*This function is passed a string file path and a hash algorithm
     * and will return a string with a hash value*/
    private string GetFileChecksum(string file, HashAlgorithm algorithm)
    {
        string result = string.Empty;

        using (FileStream fs = File.OpenRead(file))
        {
            result = BitConverter.ToString(algorithm.ComputeHash(fs)).ToLower().Replace("-", "");               //manipulate string to lower, remove dashes
        }
       
        return result;
    }
      

   
}



/*
 * class specifically for saving serialized player data
 * 
 */
[Serializable()]
 class PlayerData
{
    //Player data to be saved to file
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
    public string playerName;
   

}