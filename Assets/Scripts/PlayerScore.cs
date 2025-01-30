using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class PlayerScore : MonoBehaviour
{
    public int score = 0; // The player's score
    public TextMeshProUGUI scoreText; // Reference to the score text UI

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
    }

    // Function to update the score UI
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
