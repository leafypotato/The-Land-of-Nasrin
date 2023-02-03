using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value = 1; // Coin value.


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When interacting with the player
        if (collision.tag == "Player")
        {
            // Update the number of coins...
            LevelManager.Instance.AddCoins(value);

            // And disappears.
            Destroy(gameObject);
        }
    }
}
