using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MathQuestionGenerator : MonoBehaviour
{
    public Text questionText;
    public InputField answerInput;
    public Button submitButton;
    public Button retryButton;
    public Button continueButton;
    public Button mainMenuButton;
    public Text feedbackText;
    public Text scoreText;
    public GameObject stageCompletePanel; // Panel for stage completion

    private int currentGrade;
    private int num1, num2, correctAnswer;
    private string currentOperation;
    private int questionCount = 0;
    private int totalQuestions = 10; // Questions per stage
    private int score = 0;

    void Start()
    {
        // Get selected difficulty from GameManager
        currentGrade = GameManager.Instance.GetDifficulty();
        GenerateMathQuestion();
        UpdateScore();
    }

   public void GenerateMathQuestion()
    {
        if (questionCount >= totalQuestions)
        {
            // Stage Complete!
            StageComplete();
            return;
        }

        questionCount++;

        switch (currentGrade)
        {
            case 1: // 1st Grade: Simple Addition (1-20)
                num1 = Random.Range(1, 20);
                num2 = Random.Range(1, 20);
                currentOperation = "+";
                correctAnswer = num1 + num2;
                break;

            case 2: // 2nd Grade: Addition & Subtraction (10-50)
                num1 = Random.Range(10, 50);
                num2 = Random.Range(10, 50);
                currentOperation = (Random.value > 0.5f) ? "+" : "-";
                correctAnswer = (currentOperation == "+") ? (num1 + num2) : (num1 - num2);
                break;

            case 3: // 3rd Grade: Add, Subtract, Multiply (20-100)
                num1 = Random.Range(20, 100);
                num2 = Random.Range(1, 5);
                currentOperation = new string[] { "+", "-", "×" }[Random.Range(0, 3)];
                correctAnswer = (currentOperation == "+") ? (num1 + num2) :
                                (currentOperation == "-") ? (num1 - num2) :
                                (num1 * num2);
                break;

            case 4: // 4th Grade: Add, Subtract, Multiply (50-500)
                num1 = Random.Range(50, 500);
                num2 = Random.Range(1, 10);
                currentOperation = new string[] { "+", "-", "×" }[Random.Range(0, 3)];
                correctAnswer = (currentOperation == "+") ? (num1 + num2) :
                                (currentOperation == "-") ? (num1 - num2) :
                                (num1 * num2);
                break;

            case 5: // 5th Grade: Add, Subtract, Multiply, Divide (100-1000)
                num1 = Random.Range(100, 1000);
                num2 = Random.Range(1, 10);
                currentOperation = new string[] { "+", "-", "×", "÷" }[Random.Range(0, 4)];

                if (currentOperation == "÷")
                {
                    num1 = num2 * Random.Range(1, 10); // Ensures whole numbers
                    correctAnswer = num1 / num2;
                }
                else
                {
                    correctAnswer = (currentOperation == "+") ? (num1 + num2) :
                                    (currentOperation == "-") ? (num1 - num2) :
                                    (num1 * num2);
                }
                break;
        }

        // Update question text
        questionText.text = $"{num1} {currentOperation} {num2} = ?";
    }

    public void CheckAnswer()
    {
        int playerAnswer;
        if (int.TryParse(answerInput.text, out playerAnswer))
        {
            if (playerAnswer == correctAnswer)
            {
                feedbackText.text = "✅ Correct!";
                score += 10; // Increase score per correct answer
                UpdateScore();
                GenerateMathQuestion();
            }
            else
            {
                feedbackText.text = "❌ Wrong! Try Again.";
            }
        }
        else
        {
            feedbackText.text = "⚠ Enter a valid number.";
        }

        answerInput.text = ""; // Clear input field after submission
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void StageComplete()
    {
        Debug.Log("Stage Complete!");
        stageCompletePanel.SetActive(true); // Show stage complete UI
    }

    public void ContinueToNextStage()
    {
        currentGrade++; // Increase difficulty
        questionCount = 0; // Reset question count
        stageCompletePanel.SetActive(false); // Hide completion UI
        GenerateMathQuestion(); // Start next stage
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Load main menu scene
    }
}
