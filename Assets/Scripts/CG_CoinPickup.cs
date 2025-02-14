using UnityEngine;

public class CG_CoinPickup : MonoBehaviour
{
    private int points = 10; // Default points

    private void Start()
{
    switch (gameObject.tag)
    {
        case "RareCoin":
            points = 50;
            break;
        case "MidCoin":
            points = 30;
            break;
        case "LowCoin":
            points = 10;
            break;
        default:
            points = 5;
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
                playerScore.AddScore(points); // Add points based on coin type
            }

            Destroy(gameObject); // Remove the coin after pickup
        }
    }
}

