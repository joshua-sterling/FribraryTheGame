using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;

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
    public int npcMessageCount = 0;

    public Slider healthbar;

    public GameObject[] collectables;
    //public GameObject inventoryWindow;

    MD5 md5Hash = MD5.Create();

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

        FileStream chk = File.Create(Application.persistentDataPath
             + "/check.dat");

        PlayerData data = new PlayerData();                                                     //create an instance of serializeable player data
        data.playerCurrentHealth = controller.playerCurrentHealth;                                         //capture player data
        data.playerExperience = controller.playerExperience;
        data.questActive = controller.questActive;
        data.key = controller.key;
        data.donut = controller.donut;
        data.recipe = controller.salsaRecipe;
        data.hasQuestItem = controller.hasQuestItem;
        Debug.Log("key value saved is " + data.key);
        Debug.Log("key value saved is " + data.key);
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

        string MD5checksum = GetFileChecksum(Application.persistentDataPath + "/playerInfo.dat", new MD5CryptoServiceProvider());

        bf.Serialize(chk, MD5checksum);
        Debug.Log("checksum " + MD5checksum);
      

    }

    public bool validateFile()
    {
        BinaryFormatter bf = new BinaryFormatter();                                         //create an instance of the binary formatter
        FileStream file = File.Open(Application.persistentDataPath
             + "/check.dat", FileMode.Open);                                             //open the saved file

        string gameFileChecksum = GetFileChecksum(Application.persistentDataPath + "/playerInfo.dat", new MD5CryptoServiceProvider());

        Debug.Log("Game File checksum is: " + gameFileChecksum);

        string savedChecksum = (string)bf.Deserialize(file);

        Debug.Log("Saved file checksum is: " + savedChecksum);

        if (gameFileChecksum == savedChecksum) { return true; }
        else { return false; }
                

    }

    public void Load()
    {
        if(validateFile())
        {
            if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))                    //see if the game file even exists
            {
                BinaryFormatter bf = new BinaryFormatter();                                         //create an instance of the binary formatter
                FileStream file = File.Open(Application.persistentDataPath +
                    "/playerInfo.dat", FileMode.Open);                                             //open the saved file


                PlayerData data = (PlayerData)bf.Deserialize(file);                                 //cast the deserialized file back to a PlayerData object

                GameController.controller.playerCurrentHealth = data.playerCurrentHealth;                                     //set game data equal to saved data
                controller.playerExperience = data.playerExperience;
                controller.questActive = data.questActive;
                controller.key = data.key;
                controller.donut = data.donut;
                controller.salsaRecipe = data.recipe;
                playerPlaceHolder.calculateHealth();
                controller.hasQuestItem = data.hasQuestItem;
                Debug.Log("Data Loaded!");

                //find all potential collectables
                collectables = GameObject.FindGameObjectsWithTag("Collectable");

                //bool slotFound = false;             //see if there is room in inventory


                for (int i = 0; i < collectables.Length; i++)
                    if (data.slot01 == collectables[i].gameObject.GetComponent<Item>().itemID)
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
            else { Debug.Log("No file found!"); }
        }
        else{ Debug.Log("File is corrupted!  Cannot load."); }
       
    }

    float calculateHealth()
    {
        return playerCurrentHealth / playerMaxHealth;
    }

    private string GetFileChecksum(string file, HashAlgorithm algorithm)
    {
        string result = string.Empty;

        using (FileStream fs = File.OpenRead(file))
        {
            result = BitConverter.ToString(algorithm.ComputeHash(fs)).ToLower().Replace("-", "");
        }
       
        return result;
    }

    static string GetMd5Hash(MD5 md5Hash, string input)
    {

        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }

    // Verify a hash against a string.
    static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
    {
        // Hash the input.
        string hashOfInput = GetMd5Hash(md5Hash, input);

        // Create a StringComparer an compare the hashes.
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        if (0 == comparer.Compare(hashOfInput, hash))
        {
            return true;
        }
        else
        {
            return false;
        }
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