using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton for easy access
    public int selectedGrade = 1; // Default grade is 1st grade
    public int score = 0; // Track player score
    public int CurrentStage { get; private set; } = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep GameManager between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Called when player selects a grade difficulty
    public void SetDifficulty(int grade)
    {
        selectedGrade = grade;
        CurrentStage = 1; // Reset stage progress
        score = 0; // Reset score
        Debug.Log("Difficulty set to Grade: " + selectedGrade);
        SceneManager.LoadScene("GameScene"); // Load first stage
    }

    // Gets the selected difficulty
    public int GetDifficulty()
    {
        return selectedGrade;
    }

    // Method to go to the next stage with scaling difficulty
    public void AdvanceStage()
    {
        CurrentStage++;
        Debug.Log("Stage Completed! Moving to Stage: " + CurrentStage);

        // Increase grade-based difficulty (up to 5th grade)
        if (selectedGrade < 5)
            selectedGrade++;

        // Load appropriate scene for next stage
        if (CurrentStage == 2)
        {
            SceneManager.LoadScene("GStage2");
        }
        else
        {
            // If more stages are added, handle here
            SceneManager.LoadScene("GameScene"); // fallback or loop
        }
    }

    // Go back to main menu
    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene("MainMenu");
    }

    // Score tracking
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }

    // Optional: Reset stage manually (e.g., on quit)
    public void ResetStage()
    {
        CurrentStage = 1;
    }
}
