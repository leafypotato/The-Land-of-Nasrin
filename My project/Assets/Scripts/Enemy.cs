using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    //health values for the enemy
    public int maxHealth = 100;
    public int currentHealth;


    void Start()
    {
        //sets current health to max when game loads
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D col)
        //kills the player if slime collides with them
    {
        if (col.gameObject.name == "Player" && currentHealth > 1)
            //if slime collides with player and is alive
        {
            //runs PlayerDied function in DeathMenu script
            FindObjectOfType<DeathMenu>().PlayerDied();
        }
    }

    public void TakeDamage(int damage)
        //function for slime taking damage by player
    {
        currentHealth -= damage;
        Debug.Log("Hit");

        if (currentHealth <= 0)
        {
            //runs die if health is less than 0
            Die();
        }
    }

    void Die()
        //function for if slime is dead
    {
        //runs death animation
        animator.SetBool("IsDead", true);

        //runs deactivation of enemy code
        StartCoroutine(wait());

    }

    IEnumerator wait()
        //used so that the death animation can run
        //before the object is disabled
    {
        //waits for 1 second before disabling object
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);

    }
}
