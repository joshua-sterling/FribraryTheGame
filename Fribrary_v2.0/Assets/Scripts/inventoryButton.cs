using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryButton : MonoBehaviour {

    public int buttonID;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Image>().sprite = GameController.controller.inventory[buttonID].itemSprite;

    }
	
	// Update is called once per frame
	void Update () {
        //gameObject.GetComponent<Image>().sprite = GameController.controller.inventory[buttonID].itemSprite;

    }

    private void OnGUI()
    {
        gameObject.GetComponent<Image>().sprite = GameController.controller.inventory[buttonID].itemSprite;
       
    }

    private void OnEnable()
    {
        //gameObject.GetComponent<Image>().sprite = GameController.controller.inventory[buttonID].itemSprite;
    }
}
