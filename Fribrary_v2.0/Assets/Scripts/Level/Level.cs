using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    private int levelWidth;
    private int levelHeight;
      

    public Transform floorTile;
    public Transform stoneWallTile;
    public Transform enemy;
    public Transform barVertical;
    public Transform barhorizontal;
    public Transform table;

    //These colors will designate where to draw the respecitve tiles on the gameboard from the rough map
    public Color floorColor;                                                        
    public Color stonewallColor;
    public Color spawnPointColor;
    public Color enemyPointColor;    

    private Color[] tileColors;

    public Texture2D levelTexture;

    public Entity player;
    public Entity robot;

    public GameObject donutObject, keyObject;

    
    Vector2 robotSpawn2 = new Vector2(5, 14);


    void Start ()
    {
        levelWidth = levelTexture.width;
        levelHeight = levelTexture.height;
        LoadLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadLevel()
    {
        tileColors = new Color[levelWidth * levelHeight];
        tileColors = levelTexture.GetPixels();

        //look at every location on the game board for the rough drawing      
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
        //table placement
        Instantiate(table, new Vector3(8, 7), Quaternion.identity);
        Instantiate(table, new Vector3(12, 10), Quaternion.identity);
        Instantiate(table, new Vector3(12, 7), Quaternion.identity);
        Instantiate(table, new Vector3(8, 10), Quaternion.identity);

        //bar placement
        Instantiate(barVertical, new Vector3(3, 8), Quaternion.identity);
        Instantiate(barhorizontal, new Vector3(2,5), Quaternion.identity);


        player.transform.position = GameController.controller.playerLocation;
        //robot.transform.position = robotSpawn;

        createEnemy();

        if(GameController.controller.donut)
        {
            donutObject.SetActive(true);
            Debug.Log("Donut is active");
        }
        else
        {
            donutObject.SetActive(false);
            Debug.Log("Donut is NOT active");
        }

        if (GameController.controller.key)
        {
            keyObject.SetActive(true);
            Debug.Log("KEY is active");
        }
        else
        {
            keyObject.SetActive(false);
            Debug.Log("KEY is NOT active");
        }

    }

    public void createEnemy()
    {
        if (GameController.controller.robotsSpawned < 3)
        {
            Instantiate(robot, robotSpawn2, Quaternion.identity);
            GameController.controller.robotsSpawned += 1;
        }
    }
}

[System.Serializable]
public class tile
{
    public Color tileColor;
    public Transform tileTransform;

}