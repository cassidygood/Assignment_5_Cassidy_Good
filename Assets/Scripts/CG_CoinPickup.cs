using UnityEngine;

public class CG_CoinPickup : MonoBehaviour
{
    private int points = 10; // Default points
    public float sizeIncrease = 0.1f; // How much the player grows per coin

    private void Start()
    {
        // Assign different scores based on the coin's name
        switch (gameObject.name)
        {
            case "Ruby":
                points = 50;
                sizeIncrease = 0.3f; // Grow more for ruby coins
                break;
            case "Gold":
                points = 30;
                sizeIncrease = 0.2f;
                break;
            case "Moonstone":
                points = 10;
                sizeIncrease = 0.1f;
                break;
            default:
                points = 5; // Default value for unnamed or other coins
                sizeIncrease = 0.05f; // Smaller growth for other coins
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
