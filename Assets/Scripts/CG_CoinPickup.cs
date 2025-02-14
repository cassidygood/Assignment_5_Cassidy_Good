using UnityEngine;

public class CG_CoinPickup : MonoBehaviour
{
    private int points = 10; // Default points

    private void Start()
    {
        // Assign different scores based on the coin's name
        switch (gameObject.name)
        {
            case "Ruby":
                points = 50;
                break;
            case "Gold":
                points = 30;
                break;
            case "Moonstone":
                points = 10;
                break;
            default:
                points = 5; // Default value for unnamed or other coins
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.AddScore(points); // Add points to the player's score
            }

            // Print the coin value to the Console
            Debug.Log("Collected: " + gameObject.name + " | Value: " + points);

            Destroy(gameObject); // Remove the coin after pickup
        }
    }
}
