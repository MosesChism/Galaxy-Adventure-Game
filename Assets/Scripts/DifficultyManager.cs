using UnityEngine;

public static class DifficultyManager
{
    public static int selectedGrade = 1; // Default grade level

    public static void SetDifficulty(int gradeLevel)
    {
        selectedGrade = gradeLevel;
        Debug.Log("Selected Grade Level: " + selectedGrade);
    }
}