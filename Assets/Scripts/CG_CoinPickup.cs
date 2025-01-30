using UnityEngine;

public class CG_CoinPickup : MonoBehaviour
{
    public int points = 10; // Points given for collecting this coin

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.AddScore(points); // Add points to the player's score
            }

            Destroy(gameObject); // Remove the coin after pickup
        }
    }
}
