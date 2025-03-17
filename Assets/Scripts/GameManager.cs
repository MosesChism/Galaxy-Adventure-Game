using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton for easy access
    public int selectedGrade = 1; // Default grade is 1st grade
    public int currentStage = 1; // Track current stage
    public int score = 0; // Track player score

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
        currentStage = 1; // Reset stage progress
        score = 0; // Reset score
        Debug.Log("Difficulty set to Grade: " + selectedGrade);
        SceneManager.LoadScene("GameScene"); // Load the game scene
    }

    // Gets the selected difficulty
    public int GetDifficulty()
    {
        return selectedGrade;
    }

    // Method to increase difficulty after stage completion
    public void AdvanceStage()
    {
        currentStage++; // Increase stage count
        Debug.Log("Stage Completed! Moving to Stage: " + currentStage);
        
        // Implementing difficulty scaling (more challenging questions)
        selectedGrade++; 
        if (selectedGrade > 5) selectedGrade = 5; // Cap difficulty at 5th grade
        
        SceneManager.LoadScene("GameScene"); // Reload the scene with new difficulty
    }

    // Method to go back to the main menu
    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene("MainMenu"); // Load main menu scene
    }

    // Method to update and track score
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }
}
