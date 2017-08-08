using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObject : MonoBehaviour {

    public GameObject thingToActivate;

    public void activate()
    {
        thingToActivate.SetActive(true);
    }
}
