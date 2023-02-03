using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    //kills the player if slime collides with them
    {
        if (col.gameObject.name == "Player")
        //if slime collides with player and is alive
        {
            //runs PlayerDied function in DeathMenu script
            FindObjectOfType<DeathMenu>().PlayerDied();
        }
    }
}
