using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*This class procedurally creates a game level - it will run every time
 * the scene it is assigned to is loaded*/
public class Level : MonoBehaviour {

    private int levelWidth;                     //will control how wide the level is
    private int levelHeight;                    //will control how high the level is
      
    /*These will be assigned sprites in teh editor that designate which graphic
     * to show for each*/
    public Transform floorTile;
    public Transform stoneWallTile;
    public Transform enemy;
    public Transform barVertical;
    public Transform barhorizontal;
    public Transform table;

    /*These colors will designate where to draw the respecitve tiles on the gameboard from the rough map
     * They are specified in the editor*/
    public Color floorColor;                            //signifies which color in the tilemap represents where floor tiles will be placed                 
    public Color stonewallColor;                        //signifies which color in the tilemap represents where stone wall tiles will be placed  
    public Color spawnPointColor;                       //signifies which color in the tilemap represents where the player spawn points will be   
    public Color enemyPointColor;                       //signifies which color in the tilemap represents where the enemy spwan point will be

    private Color[] tileColors;                         //this array will hold Colors that will determine what tile goes where

    public Texture2D levelTexture;                      //this will be the tilemap assigned in the editor that shows where each tile should go

    public Entity player;                               //represents the player object for placement
    public Entity robot;                                //represents an enemy object for placement

    public GameObject donutObject, keyObject, recipeObject;     //other game objects to create
    
    Vector2 robotSpawn2 = new Vector2(5, 14);           //set a spawn point for the robot

    /*This will begin the level initialization*/
    void Start ()
    {
        levelWidth = levelTexture.width;                //set the level width based on the tilemap
        levelHeight = levelTexture.height;              //set the level height based on the tilemap
        LoadLevel();                                    //call the load level function
	}

    /*This function contorls everything necessary to generate the level*/
    void LoadLevel()
    {
        tileColors = new Color[levelWidth * levelHeight];
        tileColors = levelTexture.GetPixels();

        /*look at every location on the game board for the tilemap
         * for this map, it is only looking at floor and wall tiles */
        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                if (tileColors[x + y * levelWidth] == floorColor)                              //if the rough drawing is a floor tile color, create a floor tile object at that location
                {
                    Instantiate(floorTile, new Vector3(x, y), Quaternion.identity);             //creation of floor tile at that x,y location based on the inner and outer x,y loops
                }
                if (tileColors[x + y * levelWidth] == stonewallColor)                         //if the rough drawing is a stone wall color, create a stone wall tile object at that location
                {
                    Instantiate(stoneWallTile, new Vector3(x, y), Quaternion.identity);       //creation of stone wall at that x,y location based on the inner and outer x,y loops
                }
            }
        }
        //table placement - create instances of the table game objects and put them in position
        Instantiate(table, new Vector3(8, 7), Quaternion.identity);
        Instantiate(table, new Vector3(12, 10), Quaternion.identity);
        Instantiate(table, new Vector3(12, 7), Quaternion.identity);
        Instantiate(table, new Vector3(8, 10), Quaternion.identity);

        //bar placement - consists of a vertical piece and a horizontal piece
        Instantiate(barVertical, new Vector3(3, 8), Quaternion.identity);
        Instantiate(barhorizontal, new Vector3(2,5), Quaternion.identity);
        
        player.transform.position = GameController.controller.playerLocation;               //player object created in teh editor, move it to the designated location
        

        createEnemy();                                                                      //create an instance of the enemy

        /*Decide which game objects need to be displayed - don't want to display one
         * that has already been collected */
        if(GameController.controller.donut)
        {
            donutObject.SetActive(true);
        }
        else
        {
            donutObject.SetActive(false);
        }

        if (GameController.controller.key)
        {
            keyObject.SetActive(true);
        }
        else
        {
            keyObject.SetActive(false);
        }

        if(GameController.controller.salsaRecipe)
        {
            recipeObject.SetActive(true);
            recipeObject.transform.position = new Vector2(2, 6);                            //if recipe needs to be shown, make sure it is in the right location
        }
        else
        {
            recipeObject.SetActive(false);
        }

    }

   
    /*This function will create an instance of an enemy and count how many have been created*/
    public void createEnemy()
    {
        if (GameController.controller.robotsSpawned < 3)                                    //for the prototype, only 3 enemies will be created
        {
            Instantiate(robot, robotSpawn2, Quaternion.identity);                           //create an instance
            GameController.controller.robotsSpawned += 1;                                   //tick the count
        }
    }
}

