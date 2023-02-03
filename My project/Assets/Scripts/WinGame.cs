using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    //kills the player if slime collides with them
    {
        if (col.gameObject.name == "Player")
        //if slime collides with player and is alive
        {
            //runs PlayerDied function in DeathMenu script
            FindObjectOfType<WinMenu>().Win();
        }
    }
}

