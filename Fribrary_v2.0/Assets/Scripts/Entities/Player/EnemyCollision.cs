using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Enemy Collision controls what happens when the player object collides with an
 * enemy object in the level*/
public class EnemyCollision : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")                     //see if the collision is with an enemy based on game object tag
        {
            SceneManager.LoadScene(2);                                      //load the fight scene
        }
    }


}
