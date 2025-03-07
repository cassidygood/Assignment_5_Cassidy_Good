using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class PlayerScore : MonoBehaviour
{
    public int score = 100; // Starting score
    public TextMeshProUGUI scoreText; // Reference to the score text UI
    public float knockbackForce = 5f; // Force applied when hit (optional)

    void Start()
    {
        // Ensure the UI is updated at the start
        UpdateScoreUI();
    }

    // Function to add points
    public void AddScore(int points)
    {
        score += points; // Increase score
        UpdateScoreUI(); // Update the UI
        Debug.Log("Score: " + score);
    }

    // Function to lose points
    public void LoseScore(int points)
    {
        score -= points;
        score = Mathf.Max(score, 0); // Prevent score from going below 0
        UpdateScoreUI(); // Update UI after losing points
        Debug.Log("Player hit! Lost " + points + " points. Score: " + score);
    }

    // Function to update the score UI
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Handle collision with the enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseScore(10); // Lose 10 points if hit by an enemy

            // Optional: Apply a knockback effect
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 knockbackDirection = (transform.position - collision.transform.position).normalized;
                rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}
