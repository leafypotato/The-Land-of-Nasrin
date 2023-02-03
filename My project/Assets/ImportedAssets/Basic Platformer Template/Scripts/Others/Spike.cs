using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] int damage = 100; // Damage amount.


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When interacting with the player...
        if (collision.tag == "Player")
            // Hurt him. 
            collision.GetComponent<HealthController>().TakeDamage(damage);
    }
}
